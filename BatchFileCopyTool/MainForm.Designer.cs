namespace BatchFileCopyTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SelectSourcePathTextBox = new MetroFramework.Controls.MetroTextBox();
            this.SelectSourcePathButton = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectTargetPathButton = new MetroFramework.Controls.MetroButton();
            this.SelectTargetPathTextBox = new MetroFramework.Controls.MetroTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SubDirectoryListBox = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FileTypeListBox = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.FileNumCountLabel = new System.Windows.Forms.Label();
            this.StartCopyButton = new MetroFramework.Controls.MetroButton();
            this.CopyProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.CopyProgressLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.IncludeKeywordTextBox = new MetroFramework.Controls.MetroTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SubDirectorySelectInvertButton = new System.Windows.Forms.Button();
            this.FileTypeSelectInvertButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectSourcePathTextBox
            // 
            // 
            // 
            // 
            this.SelectSourcePathTextBox.CustomButton.Image = null;
            this.SelectSourcePathTextBox.CustomButton.Location = new System.Drawing.Point(233, 1);
            this.SelectSourcePathTextBox.CustomButton.Name = "";
            this.SelectSourcePathTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SelectSourcePathTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SelectSourcePathTextBox.CustomButton.TabIndex = 1;
            this.SelectSourcePathTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SelectSourcePathTextBox.CustomButton.UseSelectable = true;
            this.SelectSourcePathTextBox.CustomButton.Visible = false;
            this.SelectSourcePathTextBox.Lines = new string[0];
            this.SelectSourcePathTextBox.Location = new System.Drawing.Point(23, 116);
            this.SelectSourcePathTextBox.MaxLength = 32767;
            this.SelectSourcePathTextBox.Name = "SelectSourcePathTextBox";
            this.SelectSourcePathTextBox.PasswordChar = '\0';
            this.SelectSourcePathTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SelectSourcePathTextBox.SelectedText = "";
            this.SelectSourcePathTextBox.SelectionLength = 0;
            this.SelectSourcePathTextBox.SelectionStart = 0;
            this.SelectSourcePathTextBox.ShortcutsEnabled = true;
            this.SelectSourcePathTextBox.Size = new System.Drawing.Size(255, 23);
            this.SelectSourcePathTextBox.TabIndex = 1;
            this.SelectSourcePathTextBox.UseSelectable = true;
            this.SelectSourcePathTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SelectSourcePathTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // SelectSourcePathButton
            // 
            this.SelectSourcePathButton.Location = new System.Drawing.Point(284, 116);
            this.SelectSourcePathButton.Name = "SelectSourcePathButton";
            this.SelectSourcePathButton.Size = new System.Drawing.Size(75, 23);
            this.SelectSourcePathButton.TabIndex = 2;
            this.SelectSourcePathButton.Text = "选择路径";
            this.SelectSourcePathButton.UseSelectable = true;
            this.SelectSourcePathButton.Click += new System.EventHandler(this.SelectSourcePathButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "选择源目录";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(425, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "选择目标目录";
            // 
            // SelectTargetPathButton
            // 
            this.SelectTargetPathButton.Location = new System.Drawing.Point(691, 116);
            this.SelectTargetPathButton.Name = "SelectTargetPathButton";
            this.SelectTargetPathButton.Size = new System.Drawing.Size(75, 23);
            this.SelectTargetPathButton.TabIndex = 5;
            this.SelectTargetPathButton.Text = "选择路径";
            this.SelectTargetPathButton.UseSelectable = true;
            this.SelectTargetPathButton.Click += new System.EventHandler(this.SelectTargetPathButton_Click);
            // 
            // SelectTargetPathTextBox
            // 
            // 
            // 
            // 
            this.SelectTargetPathTextBox.CustomButton.Image = null;
            this.SelectTargetPathTextBox.CustomButton.Location = new System.Drawing.Point(233, 1);
            this.SelectTargetPathTextBox.CustomButton.Name = "";
            this.SelectTargetPathTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SelectTargetPathTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SelectTargetPathTextBox.CustomButton.TabIndex = 1;
            this.SelectTargetPathTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SelectTargetPathTextBox.CustomButton.UseSelectable = true;
            this.SelectTargetPathTextBox.CustomButton.Visible = false;
            this.SelectTargetPathTextBox.Lines = new string[0];
            this.SelectTargetPathTextBox.Location = new System.Drawing.Point(430, 116);
            this.SelectTargetPathTextBox.MaxLength = 32767;
            this.SelectTargetPathTextBox.Name = "SelectTargetPathTextBox";
            this.SelectTargetPathTextBox.PasswordChar = '\0';
            this.SelectTargetPathTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SelectTargetPathTextBox.SelectedText = "";
            this.SelectTargetPathTextBox.SelectionLength = 0;
            this.SelectTargetPathTextBox.SelectionStart = 0;
            this.SelectTargetPathTextBox.ShortcutsEnabled = true;
            this.SelectTargetPathTextBox.Size = new System.Drawing.Size(255, 23);
            this.SelectTargetPathTextBox.TabIndex = 7;
            this.SelectTargetPathTextBox.UseSelectable = true;
            this.SelectTargetPathTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SelectTargetPathTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(374, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 26);
            this.label3.TabIndex = 8;
            this.label3.Text = ">>";
            // 
            // SubDirectoryListBox
            // 
            this.SubDirectoryListBox.CheckOnClick = true;
            this.SubDirectoryListBox.FormattingEnabled = true;
            this.SubDirectoryListBox.Location = new System.Drawing.Point(23, 222);
            this.SubDirectoryListBox.Name = "SubDirectoryListBox";
            this.SubDirectoryListBox.Size = new System.Drawing.Size(336, 164);
            this.SubDirectoryListBox.TabIndex = 10;
            this.SubDirectoryListBox.SelectedIndexChanged += new System.EventHandler(this.SubDirectoryListBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(23, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(745, 2);
            this.label4.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(18, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "选择需要复制的子目录";
            // 
            // FileTypeListBox
            // 
            this.FileTypeListBox.CheckOnClick = true;
            this.FileTypeListBox.FormattingEnabled = true;
            this.FileTypeListBox.Location = new System.Drawing.Point(430, 222);
            this.FileTypeListBox.Name = "FileTypeListBox";
            this.FileTypeListBox.Size = new System.Drawing.Size(336, 164);
            this.FileTypeListBox.TabIndex = 13;
            this.FileTypeListBox.SelectedIndexChanged += new System.EventHandler(this.FileTypeListBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(425, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "选择需要复制的文件类型";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(20, 498);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "待复制文件数";
            // 
            // FileNumCountLabel
            // 
            this.FileNumCountLabel.AutoSize = true;
            this.FileNumCountLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FileNumCountLabel.Location = new System.Drawing.Point(121, 495);
            this.FileNumCountLabel.Name = "FileNumCountLabel";
            this.FileNumCountLabel.Size = new System.Drawing.Size(20, 22);
            this.FileNumCountLabel.TabIndex = 18;
            this.FileNumCountLabel.Text = "0";
            // 
            // StartCopyButton
            // 
            this.StartCopyButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.StartCopyButton.Location = new System.Drawing.Point(23, 537);
            this.StartCopyButton.Name = "StartCopyButton";
            this.StartCopyButton.Size = new System.Drawing.Size(127, 40);
            this.StartCopyButton.TabIndex = 19;
            this.StartCopyButton.Text = "开始复制";
            this.StartCopyButton.UseSelectable = true;
            this.StartCopyButton.Click += new System.EventHandler(this.StartCopyButton_Click);
            // 
            // CopyProgressBar
            // 
            this.CopyProgressBar.Location = new System.Drawing.Point(167, 554);
            this.CopyProgressBar.Name = "CopyProgressBar";
            this.CopyProgressBar.Size = new System.Drawing.Size(599, 23);
            this.CopyProgressBar.TabIndex = 20;
            // 
            // CopyProgressLabel
            // 
            this.CopyProgressLabel.AutoSize = true;
            this.CopyProgressLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CopyProgressLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CopyProgressLabel.Location = new System.Drawing.Point(164, 537);
            this.CopyProgressLabel.Name = "CopyProgressLabel";
            this.CopyProgressLabel.Size = new System.Drawing.Size(0, 14);
            this.CopyProgressLabel.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label9.Location = new System.Drawing.Point(574, 580);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(196, 14);
            this.label9.TabIndex = 22;
            this.label9.Text = "V1.0.0.1 20200913 by xnbbdd";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(425, 405);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 25);
            this.label8.TabIndex = 23;
            this.label8.Text = "文件名中包含的文本";
            // 
            // IncludeKeywordTextBox
            // 
            // 
            // 
            // 
            this.IncludeKeywordTextBox.CustomButton.Image = null;
            this.IncludeKeywordTextBox.CustomButton.Location = new System.Drawing.Point(314, 1);
            this.IncludeKeywordTextBox.CustomButton.Name = "";
            this.IncludeKeywordTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.IncludeKeywordTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.IncludeKeywordTextBox.CustomButton.TabIndex = 1;
            this.IncludeKeywordTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.IncludeKeywordTextBox.CustomButton.UseSelectable = true;
            this.IncludeKeywordTextBox.CustomButton.Visible = false;
            this.IncludeKeywordTextBox.Lines = new string[0];
            this.IncludeKeywordTextBox.Location = new System.Drawing.Point(430, 442);
            this.IncludeKeywordTextBox.MaxLength = 32767;
            this.IncludeKeywordTextBox.Name = "IncludeKeywordTextBox";
            this.IncludeKeywordTextBox.PasswordChar = '\0';
            this.IncludeKeywordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.IncludeKeywordTextBox.SelectedText = "";
            this.IncludeKeywordTextBox.SelectionLength = 0;
            this.IncludeKeywordTextBox.SelectionStart = 0;
            this.IncludeKeywordTextBox.ShortcutsEnabled = true;
            this.IncludeKeywordTextBox.Size = new System.Drawing.Size(336, 23);
            this.IncludeKeywordTextBox.TabIndex = 24;
            this.IncludeKeywordTextBox.UseSelectable = true;
            this.IncludeKeywordTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.IncludeKeywordTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(23, 477);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(745, 2);
            this.label10.TabIndex = 25;
            // 
            // SubDirectorySelectInvertButton
            // 
            this.SubDirectorySelectInvertButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SubDirectorySelectInvertButton.Location = new System.Drawing.Point(319, 195);
            this.SubDirectorySelectInvertButton.Name = "SubDirectorySelectInvertButton";
            this.SubDirectorySelectInvertButton.Size = new System.Drawing.Size(40, 25);
            this.SubDirectorySelectInvertButton.TabIndex = 28;
            this.SubDirectorySelectInvertButton.Text = "反选";
            this.SubDirectorySelectInvertButton.UseVisualStyleBackColor = true;
            this.SubDirectorySelectInvertButton.Click += new System.EventHandler(this.SubDirectorySelectInvertButton_Click);
            // 
            // FileTypeSelectInvertButton
            // 
            this.FileTypeSelectInvertButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FileTypeSelectInvertButton.Location = new System.Drawing.Point(726, 195);
            this.FileTypeSelectInvertButton.Name = "FileTypeSelectInvertButton";
            this.FileTypeSelectInvertButton.Size = new System.Drawing.Size(40, 25);
            this.FileTypeSelectInvertButton.TabIndex = 29;
            this.FileTypeSelectInvertButton.Text = "反选";
            this.FileTypeSelectInvertButton.UseVisualStyleBackColor = true;
            this.FileTypeSelectInvertButton.Click += new System.EventHandler(this.FileTypeSelectInvertButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 600);
            this.Controls.Add(this.FileTypeSelectInvertButton);
            this.Controls.Add(this.SubDirectorySelectInvertButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.IncludeKeywordTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CopyProgressLabel);
            this.Controls.Add(this.CopyProgressBar);
            this.Controls.Add(this.StartCopyButton);
            this.Controls.Add(this.FileNumCountLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FileTypeListBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SubDirectoryListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SelectTargetPathTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectTargetPathButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectSourcePathButton);
            this.Controls.Add(this.SelectSourcePathTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = " 批量文件复制工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox SelectSourcePathTextBox;
        private MetroFramework.Controls.MetroButton SelectSourcePathButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroButton SelectTargetPathButton;
        private MetroFramework.Controls.MetroTextBox SelectTargetPathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox SubDirectoryListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox FileTypeListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label FileNumCountLabel;
        private MetroFramework.Controls.MetroButton StartCopyButton;
        private MetroFramework.Controls.MetroProgressBar CopyProgressBar;
        private System.Windows.Forms.Label CopyProgressLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private MetroFramework.Controls.MetroTextBox IncludeKeywordTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button SubDirectorySelectInvertButton;
        private System.Windows.Forms.Button FileTypeSelectInvertButton;
    }
}

