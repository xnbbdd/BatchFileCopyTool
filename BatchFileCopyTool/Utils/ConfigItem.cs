using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchFileCopyTool.Utils
{
    class ConfigItem
    {
        public int LineNo = -1;
        public string SectionName = "Others";
        public string Key = null;
        public string Value = null;
        public bool IsSectionName = false;
        public object Tag;

        public ConfigItem()
        {

        }

        public ConfigItem(string key, string value)
        {
            key = key == null || key.Trim() == "" ? "" : key.Trim();

            if (key.Contains("."))
            {
                int p = key.LastIndexOf('.');
                SectionName = key.Substring(0, p);
                Key = key.Substring(p + 1);
            }
            else
            {
                SectionName = "Others";
                Key = key;
            }

            Value = value;
        }


        /// <summary>
        /// 返回文本化内容，格式为 LineNo: FieldName.Key=Value
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{SectionName}.{Key}={Value}";
        }

        /// <summary>
        /// 带域名的全键名。
        /// </summary>
        public string FullKey { get { return SectionName + "." + Key; } }

        /// <summary>
        /// 对给定的字符串进行解析。有以下几种情况。
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static ConfigItem Parse(string line)
        {
            // 几种情况返回为空。
            if (line == null || line.Trim().Length == 0)
                return null;

            // 本行为空则返回
            string s = line.TrimStart();
            if (s.Length == 0)
                return null;

            // 注释的行忽略
            if (s.StartsWith("//") || s.StartsWith("#"))
                return null;

            ConfigItem ci = new ConfigItem();

            // 以 [ 开头的表示是段的切换
            if (s.StartsWith("[") && s.EndsWith("]"))
            {
                s = s.Trim('[', ']').Trim();
                if (s.Length > 1) // 即在[]之间的内容长度至少为1
                {
                    ci.IsSectionName = true;
                    ci.SectionName = s;
                }
                else
                    return null;

                return ci;
            }

            // 以等号拆分字符串
            string[] pair = split(s, '=');
            if (pair != null)
            {
                string[] secs = pair[0].Split('.');
                ci.Key = secs[secs.Length - 1];
                ci.Value = pair[1];
            }

            return ci;
        }

        /// <summary>
        /// 根据给定的分隔符，只以第一个分隔符为界，将对给定字符串进行拆分2段。
        /// 设separtor为=，有以下几种情况：
        /// a=b  拆分结果为 {a,b}
        /// a==b 拆分结果为 {a, =b}
        /// a=b= 拆分结果为 {a, b=}
        /// a=   拆分结果为 {a, ""}
        /// a    拆分结果为 {a, null}
        /// =    拆分结果为 null
        /// =b   拆分结果为 null 
        ///      拆分结果为 null   
        /// 返回的正确结果为两个trim后长度均不空为的字符串，否则返回 null.
        /// </summary>
        /// <param name="tobesplit">待拆分字符串。</param>
        /// <param name="separator"></param>
        /// <returns></returns>
        static string[] split(string tobesplit, char separator = '=')
        {
            if (tobesplit == null || tobesplit.Trim().Length == 0)
                return null;

            string[] ss = new string[2];

            int p = tobesplit.IndexOf(separator);
            if (p > 0)
            {
                ss[0] = tobesplit.Substring(0, p).Trim();
                ss[1] = tobesplit.Substring(p + 1).Trim(); // + 1 是为了跳过 separator 
            }
            else if (p < 0)
            {
                ss[0] = tobesplit;
            }
            else
            {
                ss = null;
            }

            return ss;
        }
    }
}
