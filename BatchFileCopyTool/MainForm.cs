﻿using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BatchFileCopyTool
{
    public partial class MainForm : MetroForm
    {
        private string selectSourcePath;//源目录
        private string selectTargetPath;//目标目录
        private List<string> subDirectoryList;//扫描出的子目录list
        private List<List<string>> filePathList;//扫描出的所有文件路径
        private List<List<string>> fileNameList;//扫描出的所有文件名
        private HashSet<string> fileTypeMap;//扫描出的文件类型map
        private HashSet<string> selectedSubDirectoryMap;//选择的子目录
        private HashSet<string> selectedFileTypeMap;//选择的文件类型
        private HashSet<string> copyFilePathMap;//待拷贝的文件路径map
        private int fileNumCount;//待复制文件数
        private List<int> subDirectoryIndexList;//子目录list索引值
        private ConfigAccess ca;//

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //初始化变量
            selectSourcePath = "";
            selectTargetPath = "";
            subDirectoryList = new List<string>();
            copyFilePathMap = new HashSet<string>();
            fileTypeMap = new HashSet<string>();
            selectedSubDirectoryMap = new HashSet<string>();
            selectedFileTypeMap = new HashSet<string>();
            subDirectoryIndexList = new List<int>();
            filePathList = new List<List<string>>();
            fileNameList = new List<List<string>>();

            //创建配置文件
            ca = new ConfigAccess("config.ini");
            selectSourcePath = ca.GetString("selectSourcePath");
            selectTargetPath = ca.GetString("selectTargetPath");
            this.IncludeKeywordTextBox.Text = ca.GetString("HsKeyword");

            //初始化界面
            this.SelectSourcePathTextBox.Text = selectSourcePath;
            this.SelectTargetPathTextBox.Text = selectTargetPath;
            if (!selectSourcePath.Trim().Equals("")) 
            {
                UpdatesubDirectoryListBox();
            }
            //初始化文件类型勾选
            if (fileTypeMap.Count > 0) {
                String fileTypeStr = ca.GetString("HsFileTpye").Trim();
                if (!fileTypeStr.Equals(""))
                {
                    string[] fileTypeArr = fileTypeStr.Split(new char[] { '|' });
                    for (int i = 0; i < FileTypeListBox.Items.Count; i++)
                    {
                        String itemStr = FileTypeListBox.GetItemText(FileTypeListBox.Items[i]);
                        foreach (var fileType in fileTypeArr)
                        {
                            if (itemStr.Equals(fileType)) {
                                FileTypeListBox.SetItemChecked(i, true);
                                break;
                            }
                        }
                    }
                    updateSelectFileTypeList();
                }
            }
            //初始化子目录勾选
            if (subDirectoryList.Count > 0) {
                String subDirectoryStr = ca.GetString("HsSubDirectory").Trim();
                if (!subDirectoryStr.Equals(""))
                {
                    string[] subDirectoryArr = subDirectoryStr.Split(new char[] { '|' });
                    for (int i = 0; i < SubDirectoryListBox.Items.Count; i++)
                    {
                        String itemStr = SubDirectoryListBox.GetItemText(SubDirectoryListBox.Items[i]);
                        foreach (var subDirectory in subDirectoryArr)
                        {
                            if (itemStr.Equals(subDirectory))
                            {
                                SubDirectoryListBox.SetItemChecked(i, true);
                                break;
                            }
                        }
                    }
                    updateSelectSubDirectoryList();
                }
            }
        }

        //选择源目录按钮
        private void SelectSourcePathButton_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "请选择源目录";
                dialog.SelectedPath = this.SelectSourcePathTextBox.Text.Trim();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //重新初始化
                    this.SubDirectoryListBox.Items.Clear();
                    this.FileTypeListBox.Items.Clear();
                    fileTypeMap = new HashSet<string>();
                    copyFilePathMap = new HashSet<string>();
                    subDirectoryList = new List<string>();
                    selectedSubDirectoryMap = new HashSet<string>();
                    selectedFileTypeMap = new HashSet<string>();
                    subDirectoryIndexList = new List<int>();
                    filePathList = new List<List<string>>();
                    fileNameList = new List<List<string>>();
                    this.CopyProgressLabel.Text = "";
                    this.CopyProgressBar.Value = 0;

                    selectSourcePath = dialog.SelectedPath;
                    //写入配置文件
                    ca.SetValue("selectSourcePath", selectSourcePath);
                    ca.Save();

                    this.SelectSourcePathTextBox.Text = selectSourcePath;

                    UpdatesubDirectoryListBox();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("可能原因:输入路径非有效路径\n" + exc, "发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //选择目标目录按钮
        private void SelectTargetPathButton_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "请选择目标目录";
                dialog.SelectedPath = this.SelectTargetPathTextBox.Text.Trim();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectTargetPath = dialog.SelectedPath;
                    //写入配置文件
                    ca.SetValue("selectTargetPath", selectTargetPath);
                    ca.Save();
                    this.SelectTargetPathTextBox.Text = selectTargetPath;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("可能原因:输入路径非有效路径\n" + exc, "发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        /*
         * 获得指定路径下所有目录名
         * string path      文件路径
         */
        private List<string> GetSubDirectory(string path) {
            try
            {
                List<string> directoryNameList = new List<string>();
                DirectoryInfo root = new DirectoryInfo(path);
                foreach (DirectoryInfo d in root.GetDirectories())
                {
                    directoryNameList.Add(d.FullName);
                    GetFilePath(d.FullName);

                    //填充子目录选择list
                    this.SubDirectoryListBox.Items.Add(d.Name);
                }
                return directoryNameList;
            }
            catch (Exception e)
            {
                MessageBox.Show("原因:" + e, "发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /*
         * 获得指定路径下所有文件路径
         * string path      文件夹路径
         */
        private void GetFilePath(string path)
        {
            try
            {
                List<string> filePathMap = new List<string>();
                List<string> fileNameMap = new List<string>();
                DirectoryInfo root = new DirectoryInfo(path);
                foreach (FileInfo f in root.GetFiles())
                {
                    filePathMap.Add(f.FullName);
                    fileNameMap.Add(f.Name);
                    if (!f.Extension.Equals(""))
                    {
                        fileTypeMap.Add(f.Extension);
                    }
                }
                filePathList.Add(filePathMap);
                fileNameList.Add(fileNameMap);
            }
            catch (Exception e)
            {
                MessageBox.Show("原因:" + e, "发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //更新待复制文件数
        private void updateFileNumCount()
        {
            copyFilePathMap = new HashSet<string>();

            if (subDirectoryIndexList.Count == 0 || selectedFileTypeMap.Count == 0) {
                fileNumCount = 0;
                this.FileNumCountLabel.Text = fileNumCount + "";
                return;
            }

            string keyword = this.IncludeKeywordTextBox.Text;
            foreach (var index in subDirectoryIndexList)
            {
                List<string> filePathMap = filePathList[index];
                List<string> fileNameMap = fileNameList[index];
                for (int i = 0; i < fileNameMap.Count; i++)
                {
                    foreach (var fileType in selectedFileTypeMap)
                    {
                        if (keyword.Equals(""))
                        {
                            if (fileNameMap[i].Contains(fileType))
                            {
                                copyFilePathMap.Add(filePathMap[i]);
                                break;
                            }
                        }
                        else {
                            if (fileNameMap[i].Contains(fileType) && fileNameMap[i].Contains(keyword))
                            {
                                copyFilePathMap.Add(filePathMap[i]);
                                break;
                            }
                        }
                    }
                }
            }
            fileNumCount = copyFilePathMap.Count;
            this.FileNumCountLabel.Text = fileNumCount + "";
        }

        //保存已选子目录至配置文件中
        private void saveSubDirectory() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int countNum = subDirectoryIndexList.Count;
            int i = 0;
            foreach (var index in subDirectoryIndexList)
            {
                string subDirectory = subDirectoryList[index].Substring(subDirectoryList[index].LastIndexOf('\\') + 1);
                sb.Append(subDirectory);
                if (i + 1 != countNum)
                {
                    sb.Append("|");
                }
                i++;
            }
            ca.SetValue("HsSubDirectory", sb.ToString());
            ca.Save();
        }

        //保存已选文件类型至配置文件中
        private void saveFileTpye()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int countNum = selectedFileTypeMap.Count;
            int i = 0;
            foreach (var fileType in selectedFileTypeMap)
            {
                sb.Append(fileType);
                if (i + 1 != countNum)
                {
                    sb.Append("|");
                }
                i++;
            }
            ca.SetValue("HsFileTpye", sb.ToString());
            ca.Save();
        }

        //保存搜索关键字至配置文件中
        private void saveKeyword()
        {
            string keyword = this.IncludeKeywordTextBox.Text;
            ca.SetValue("HsKeyword", keyword);
            ca.Save();
        }

        //子目录选择list 选择项改变
        private void SubDirectoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateSelectSubDirectoryList();
        }

        //文件类型选择list 选择项改变
        private void FileTypeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateSelectFileTypeList();
        }

        //更新已选的子目录list
        private void updateSelectSubDirectoryList() {
            subDirectoryIndexList = new List<int>();
            for (int i = 0; i < SubDirectoryListBox.Items.Count; i++)
            {
                if (SubDirectoryListBox.GetItemChecked(i))
                {
                    subDirectoryIndexList.Add(i);
                }
            }
        }

        //更新已选的文件类型list
        private void updateSelectFileTypeList() {
            for (int i = 0; i < FileTypeListBox.Items.Count; i++)
            {
                string fileType = FileTypeListBox.GetItemText(FileTypeListBox.Items[i]);
                if (FileTypeListBox.GetItemChecked(i))
                {
                    selectedFileTypeMap.Add(fileType);
                }
                else
                {
                    if (selectedFileTypeMap.Contains(fileType))
                    {
                        selectedFileTypeMap.Remove(fileType);
                    }
                }
            }
        }

        //开始复制按钮
        private void StartCopyButton_Click(object sender, EventArgs e)
        {
            this.CopyProgressLabel.Text = "";
            this.CopyProgressBar.Value = 0;
            updateFileNumCount();

            selectSourcePath = this.SelectSourcePathTextBox.Text;
            selectTargetPath = this.SelectTargetPathTextBox.Text;
            if (selectSourcePath.Trim().Equals(""))
            {
                MessageBox.Show("未选择源目录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (selectTargetPath.Trim().Equals(""))
            {
                MessageBox.Show("未选择目标目录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //检查目标目录是否合法
            try
            {
                DirectoryInfo root = new DirectoryInfo(selectTargetPath);
                Regex regex = new Regex(@"^([a-zA-Z]:\\)?[^\/\:\*\?\""\<\>\|\,]*$");
                Match m = regex.Match(selectTargetPath);
                if (!m.Success)
                {
                    MessageBox.Show("非法的目标目录路径，请重新选择或输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!selectTargetPath.Contains(":\\")) {
                    MessageBox.Show("非法的目标目录路径，请重新选择或输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception exc) {
                MessageBox.Show("非法的目标目录路径，请重新选择或输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            //如果目标目录为空则创建
            if (!Directory.Exists(selectTargetPath))
            { 
                Directory.CreateDirectory(selectTargetPath);
            }

            if (copyFilePathMap.Count == 0)
            {
                MessageBox.Show("复制文件数为0", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string tipsText = "";
            foreach (var copyFilePath in copyFilePathMap)
            {
                tipsText = tipsText + copyFilePath + "\r\n";
            }

            PassData.isOk = false;
            PassData.longMsg = tipsText;
            LongMsgBox longMsgBox = new LongMsgBox();
            longMsgBox.ShowDialog();

            if (PassData.isOk)
            {
                CopyFileHandler();
            }

            //复制成功保存配置信息
            ca.SetValue("selectTargetPath", selectTargetPath);
            ca.SetValue("selectSourcePath", selectSourcePath);
            ca.Save();
            saveSubDirectory();
            saveFileTpye();
            saveKeyword();
        }

        //复制文件处理
        private void CopyFileHandler() {
            try
            {
                Double currentNum = 0;
                Double countNum = Convert.ToDouble(copyFilePathMap.Count);
                UpdateProgress(currentNum, countNum);
                foreach (var copyFilePath in copyFilePathMap)
                {
                    string fileName = copyFilePath.Substring(copyFilePath.LastIndexOf('\\'));
                    File.Copy(copyFilePath, selectTargetPath + "\\" + fileName, true);
                    currentNum++;
                    UpdateProgress(currentNum, countNum);
                }
                MessageBox.Show("复制成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e) {
                MessageBox.Show("原因:" + e, "发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //更新进度
        private void UpdateProgress(Double currentNum, Double countNum) {
            this.CopyProgressLabel.Text = Convert.ToInt32(currentNum) + "/" + Convert.ToInt32(countNum) ;
            this.CopyProgressBar.Value = Convert.ToInt32((currentNum / countNum)*100);
        }

        //更新子目录listbox
        private void UpdatesubDirectoryListBox() {
            subDirectoryList = GetSubDirectory(selectSourcePath);
            //填充文件类型选择list
            foreach (var fileType in fileTypeMap)
            {
                this.FileTypeListBox.Items.Add(fileType);
            }
        }

        //子目录list反选
        private void SubDirectorySelectInvertButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < SubDirectoryListBox.Items.Count; i++)
            {
                if (SubDirectoryListBox.GetItemChecked(i))
                {
                    SubDirectoryListBox.SetItemChecked(i, false);
                }
                else
                {
                    SubDirectoryListBox.SetItemChecked(i, true);
                }
            }
            updateSelectSubDirectoryList();
        }

        //文件类型list反选
        private void FileTypeSelectInvertButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < FileTypeListBox.Items.Count; i++)
            {
                if (FileTypeListBox.GetItemChecked(i))
                {
                    FileTypeListBox.SetItemChecked(i, false);
                }
                else
                {
                    FileTypeListBox.SetItemChecked(i, true);
                }
            }
            updateSelectFileTypeList();
        }
    }
}
