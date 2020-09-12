using BatchFileCopyTool.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/* 2019-04-23 郝老师
* 进行了大幅修改，主要包括
* - 增加了很多Get方法，基本都有两个函数：Get(key, defaultValue)和Get(section, key, defaultValue)
* - 调整了参数的格式
* - 调整的读写时SectionName和Key的关系
* - 修正了一些BUG
* 2019-05-22 郝老师
* - 添加了 RemoveItem(key) 方法
* - 添加了 ReadValue 和 WriteValue 两个静态方法不用初始化变量即可使用
* - 对 GetXXX 函数进行了统一，包括 GetXXX(section, key, defaultValue) 和 GetXXX(key, defaultValue) 两个函数。
* - 添加了GetBoolean方法
* 2019-5-27 郝老师
* - /r 和 /n 都使用不同的32位特殊字符串进行替换表示。
*/
namespace BatchFileCopyTool
{
    /// <summary>
    /// * 配置文件以段进行划分，每个段有多个 key-value 项；
    /// * 段名的格式为 `[$段名]`， 其中 `$段名` 为字母、数字和下划线组成，如 `[System]`，`[Part_1]`，`[Others]`；
    /// * 每个 key 都有唯一对应的段名，其中段名格式 为字母、数字、点和下划线组成；
    /// * key 和段名使用点（.) 连接，如 `System.Encoding` ，如果key中不包括点，则会被当成默认段`Others`来处理，如 `Encoding` 会被当成 `Others.Encoding` 来处理。
    /// * 如果在同一个文件中相同的 key 出现多次，取第一次出现的值，忽略后面的值；
    /// * value 的内容无限制，最小长度为0；
    /// * 以 # 或 // 头的行会被当成注释而会忽略；
    /// * value中的换行符（即 `/n`）会被替换为一个长度为15的特殊字符串，从而保证在换行时不受影响。
    /// * 在配置文件中的行的开头的空格会被忽略；
    /// * 配置文件默认使用 Encoding.UTF8 进行编码。
    /// </summary>
    class ConfigAccess
    {
        #region 属性域
        /// <summary>
        /// 读写文件时的编码，默认为Encoding.Default，即ANSI。
        /// </summary>
        public Encoding FileEncoding { get; set; } = Encoding.UTF8;

        /// <summary>
        /// 所有的域名。
        /// </summary>
        List<string> sectionNames { get; set; } = new List<string>();

        /// <summary>
        /// 数据存入的核心变量，所有的配置数据都写于此。
        /// </summary>
        Dictionary<string, ConfigItem> map = new Dictionary<string, ConfigItem>();

        string filepath = "config.ini";
        string slashn = "39^2d9@:a-sj0?0*0=40fa]42&!o4df1";
        string slashr = "40-&!?0*40s(fo9@:2fd=d319a]j0^24";


        #endregion

        #region 构造函数
        /// <summary>
        /// 无参数的构造函数。
        /// </summary>
        public ConfigAccess() { Load(); }

        /// <summary>
        /// 根据给定文件加载数据。
        /// </summary>
        /// <param name="filepath">给定文件。</param>
        public ConfigAccess(string filepath)
        {
            Load(filepath);
        }

        /// <summary>
        /// 根据给定文件加载数据。
        /// </summary>
        /// <param name="filepath">给定文件。</param>
        public ConfigAccess(string filepath, Encoding encoding)
        {
            FileEncoding = encoding;
            Load(filepath);
        }
        #endregion

        #region 读写方法
        /// <summary>
        /// 从文件中读取配置信息。
        /// </summary>
        /// <param name="file">需要加载的文件</param>
        /// <returns>返回true表示加载成功，否则加载失败。</returns>
        public bool Load(string file = "config.ini")
        {
            if (!File.Exists(file))
                File.Create(file).Close();

            filepath = file;
            sectionNames = new List<string>();
            string currentSection = "Others";
            map = new Dictionary<string, ConfigItem>();
            string[] lines = File.ReadAllLines(file, FileEncoding);
            int lineNo = -1;
            foreach (string line in lines)
            {
                lineNo++;

                ConfigItem ci = ConfigItem.Parse(line);
                if (ci == null)
                    continue;

                if (ci.IsSectionName)
                {
                    currentSection = ci.SectionName;
                    continue;
                }

                if (ci.Key == null)
                    continue;

                ci.LineNo = lineNo;
                ci.SectionName = currentSection;

                // 如果值不存在则添加
                if (!map.Keys.Contains(ci.FullKey))
                {
                    map.Add(ci.FullKey, ci);
                    if (!sectionNames.Contains(currentSection))
                        sectionNames.Add(currentSection);
                }
            }

            return true;
        }

        /// <summary>
        /// 将所有内容保存至的文件，如果文件不存在则新建，如果已经存在 ，则覆盖。
        /// </summary>
        /// <param name="file">保存文件的路径。</param>
        /// <returns></returns>
        public bool Save(string file = null, Encoding encoding = null)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string section in sectionNames)
            {
                sb.Append($"[{section}]\n");
                foreach (var key in GetItemsBySectionName(section))
                {
                    sb.Append($"{key.Key}={key.Value}\n");
                }
            }

            File.WriteAllText(file ?? (filepath ?? "config.ini"), sb.ToString(), encoding ?? FileEncoding);
            return true;
        }
        #endregion

        #region 提供了大量Get和Set方法
        /// <summary>
        /// 返回所有的键。返回的键值为完整键值，包含域名。
        /// </summary>
        /// <returns></returns>
        public List<string> GetKeys(string section = null)
        {
            List<string> keys = new List<string>();
            if (map != null)
                foreach (var key in map.Keys)
                    if (section == null || key.StartsWith(section))
                        keys.Add(key);
            return keys;
        }

        /// <summary>
        /// 返回所有的值。
        /// </summary>
        /// <returns></returns>
        public List<string> GetValues()
        {
            List<string> values = new List<string>();
            foreach (var key in GetKeys())
            {
                values.Add(GetValue(key));
            }
            return values;
        }

        /// <summary>
        /// 移除空格并将 null 转换为 ""，最终返回完全的 section.key 格式的名称
        /// </summary>
        /// <param name="section">段名。</param>
        /// <param name="key">键名。</param>
        /// <returns></returns>
        public string GetFullKey(string section, string key)
        {
            key = key == null || key.Trim().Length == 0 ? "" : key.Trim();
            section = section == null || section.Trim().Length == 0 ? "Others" : section.Trim();
            return key.Contains(".") ? key : $"{section}.{key}";
        }


        /// <summary>
        /// 返回所有的段名称。
        /// </summary>
        /// <returns></returns>
        public List<String> GetSectionNames()
        {
            return sectionNames;
        }


        /// <summary>
        /// 向指定的key值写入指定的bool类型的值。如果key不存在会创建，否则会进行更新。
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">待写入的值。</param>
        public void SetBoolean(string key, bool value)
        {
            SetValue("Others", key, value.ToString());
        }

        /// 向指定的key值写入指定值。如果key不存在会创建，否则会进行更新。
        /// </summary>
        /// <param name="section">section</param>
        /// <param name="key">Key</param>
        /// <param name="value">待写入的值。</param>
        public void SetBoolean(string section, string key, bool value)
        {
            SetValue(section, key, value.ToString());
        }


        /// <summary>
        /// 向指定的key值写入指定值。如果key不存在会创建，否则会进行更新。
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">待写入的值。</param>
        public void SetValue(string key, object value)
        {
            SetValue("Others", key, value);
        }

        /// <summary>
        /// 向指定的key值写入指定值。如果key不存在会创建，否则会进行更新。
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="objValue">待写入的值。</param>
        public void SetValue(string section, string key, object objValue)
        {
            if (objValue != null)
            {
                string Key = GetFullKey(section, key);
                string value = objValue.ToString();
                value = value.Replace("\r", slashr).Replace("\n", slashn);
                if (map.Keys.Contains(Key))
                    map[Key].Value = value;
                else
                {
                    ConfigItem item = new ConfigItem(Key, value);
                    if (!sectionNames.Contains(item.SectionName))
                        sectionNames.Add(item.SectionName);
                    map.Add(Key, item);
                }
            }
        }

        /// <summary>
        /// 根据key从当前 key-value 列表中移除已有项。返回true表示移除成功。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool RemoveItem(string key, string section = "Others")
        {
            String Key = GetFullKey(section, key);
            if (map.Keys.Contains(Key))
            {
                map.Remove(Key);
                return true;
            }

            return false;
        }


        /// <summary>
        /// 返回对应键值的项，为了方便某些操作。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public ConfigItem GetItem(string key)
        {
            key = key.Contains(".") ? key : $"Others.{key}";
            return map.Keys.Contains(key) ? map[key] : null;
        }

        public ConfigItem GetItem(string section, string key)
        {
            key = key.Contains(".") ? key : $"{section}.{key}";
            return map.Keys.Contains(key) ? map[key] : null;
        }

        /// <summary>
        /// 根据域名，返回相同域名的所有的ConfigItem。
        /// </summary>
        /// <param name="section">域名，默认为 Others</param>
        /// <returns></returns>
        public List<ConfigItem> GetItemsBySectionName(string section = "Others")
        {
            List<ConfigItem> items = new List<ConfigItem>();
            foreach (var item in map.Values)
            {
                if (item.SectionName == section)
                {
                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 返回指定key的String类型的值，如果不存在 则返回输入的缺省值。
        /// 注：key 的默认段为　
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="defaultValue">如果key不存在时的返回的缺省值。</param>
        /// <returns></returns>
        public String GetString(string key)
        {
            return GetValue("Others", key, "");
        }

        /// <summary>
        /// 返回指定key的String类型的值，如果不存在 则返回输入的缺省值。
        /// 注：key 的默认段为　
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="defaultValue">如果key不存在时的返回的缺省值。</param>
        /// <returns></returns>
        public String GetString(string section, string key, string defaultValue = null)
        {
            return GetValue(section, key, defaultValue);
        }

        /// <summary>
        /// 返回指定key的String类型的值，如果不存在 则返回输入的缺省值。
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="defaultValue">读取失败时返回的值，默认为 null。</param>
        /// <param name="section">所在的段，默认为 Others</param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            return GetValue("Others", key, "");
        }

        /// <summary>
        /// 返回指定key的String类型的值，如果不存在 则返回输入的缺省值。
        /// </summary>
        /// <param name="section">段名。</param>
        /// <param name="key">键名。</param>
        /// <param name="defaultValue">缺省值。</param>
        /// <returns></returns>
        public string GetValue(string section, string key, string defaultValue = "")
        {
            string Key = GetFullKey(section, key);
            string value = map.Keys.Contains(Key) ? map[Key].Value : defaultValue;
            return value?.Replace(slashn, "\n").Replace(slashr, "\r");
        }




        /// <summary>
        /// 返回指定key的Int32类型的值，如果不存在 则返回输入的缺省值(不写时返回int.MaxValue)。
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="defaultValue">如果key不存在时的返回的缺省值。</param>
        /// <returns></returns>
        public int GetInt(string key, int defaultValue = int.MaxValue)
        {
            try
            {
                return int.Parse(GetString(key), null);
            }
            catch { }
            return defaultValue;
        }


        /// <summary>
        /// 返回指定key的Int32类型的值，如果不存在 则返回输入的缺省值(不写时返回int.MaxValue)。
        /// </summary>
        /// <param name="section">所在的域。</param>
        /// <param name="key">key</param>
        /// <param name="defaultValue">如果key不存在时的返回的缺省值。</param>
        /// <returns></returns>
        public int GetInt(string section, string key, int defaultValue = int.MaxValue)
        {
            try
            {
                return int.Parse(GetString(section, key, null));
            }
            catch { }
            return defaultValue;
        }


        /// <summary>
        /// 返回指定key的Float32类型的值，如果不存在 则返回输入的缺省值(不写时返回NaN)。
        /// </summary>
        /// <param name="section">所在的域。</param>
        /// <param name="key">key</param>
        /// <param name="defaultValue">如果key不存在时的返回的缺省值。</param>
        /// <returns></returns>
        public float GetFloat(string key, float defaultValue = float.NaN)
        {
            try
            {
                return float.Parse(GetString(key));
            }
            catch { }
            return defaultValue;
        }

        /// <summary>
        /// 返回指定key的Float32类型的值，如果不存在 则返回输入的缺省值(不写时返回NaN)。
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="defaultValue">如果key不存在时的返回的缺省值。</param>
        /// <returns></returns>
        public float GetFloat(string section, string key, float defaultValue = float.NaN)
        {
            try
            {
                return float.Parse(GetString(section, key, null));
            }
            catch { }
            return defaultValue;
        }


        /// <summary>
        /// 返回指定key的DateTime类型的值，如果没有正解解析，则反正 DateTime.Now。
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="defaultValue">如果key不存在时的返回的缺省值。</param>
        /// <returns></returns>
        public DateTime GetDateTime(string key)
        {
            try
            {
                return DateTime.Parse(GetString(key, null));
            }
            catch { }

            return DateTime.Now;
        }

        /// <summary>
        /// 返回指定key的DateTime类型的值，如果不存在 则返回输入的缺省值。
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="defaultValue">如果key不存在时的返回的缺省值。</param>
        /// <returns></returns>
        public DateTime GetDateTime(string key, DateTime defaultValue)
        {
            try
            {
                return DateTime.Parse(GetString(key, null));
            }
            catch { }

            return defaultValue;
        }


        /// <summary>
        /// 返回指定key的DateTime类型的值，如果不存在 则返回输入的缺省值。
        /// </summary>
        /// <param name="section">所在的域。</param>
        /// <param name="key">key</param>
        /// <param name="defaultValue">如果key不存在时的返回的缺省值。</param>
        /// <returns></returns>
        public DateTime GetDateTime(string section, string key, DateTime defaultValue)
        {
            try
            {
                return DateTime.Parse(GetString(section, key, null));
            }
            catch { }
            return defaultValue;
        }


        /// <summary>
        /// 返回指定key的DateTime类型的值，如果不存在 则返回输入的缺省值。
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="defaultValue">如果key不存在时的返回的缺省值。</param>
        /// <returns></returns>
        public DateTime GetDateTimeExact(string key, string format, DateTime defaultValue)
        {
            try
            {
                return DateTime.ParseExact(GetString(key), format, null);
            }
            catch { }
            return defaultValue;
        }

        /// <summary>
        /// 返回指定key的DateTime类型的值，如果不存在 则返回输入的缺省值。
        /// </summary>
        /// <param name="section">所在的域。</param>
        /// <param name="key">key</param>
        /// <param name="format">日期的格式。</param>
        /// <param name="defaultValue">如果key不存在时的返回的缺省值。</param>
        /// <returns></returns>
        public DateTime GetDateTimeExact(string section, string key, string format, DateTime defaultValue)
        {
            try
            {
                return DateTime.ParseExact(GetString(section, key, null), format, null);
            }
            catch { }
            return defaultValue;
        }



        /// <summary>
        /// 返回指定key的 double 类型的值，如果不存在 则返回输入的缺省值(不写时返回NaN)。
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="defaultValue">如果key不存在时的返回的缺省值。</param>
        /// <returns></returns>
        public double GetDouble(string key, double defaultValue = double.NaN)
        {
            try
            {
                return double.Parse(GetString(key));
            }
            catch { }
            return defaultValue;
        }


        /// <summary>
        /// 返回指定key的 double 类型的值，如果不存在 则返回输入的缺省值(不写时返回NaN)。
        /// </summary>
        /// <param name="section">指定的域。</param>
        /// <param name="key">key</param>
        /// <param name="defaultValue">如果key不存在时的返回的缺省值。</param>
        /// <returns></returns>
        public double GetDouble(string section, string key, double defaultValue = double.NaN)
        {
            try
            {
                return double.Parse(GetString(section, key, null));
            }
            catch { }
            return defaultValue;
        }

        /// <summary>
        /// 返回指定key的 bool 类型的值，如果不存在 则返回输入的缺省值(默认false)
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="defaultValue">如果key不存在时的返回的缺省值。</param>
        /// <returns></returns>
        public bool GetBoolean(string key, bool defaultValue = false)
        {
            try
            {
                return GetString(key, "false").ToLower() == "true";
            }
            catch { }
            return defaultValue;
        }

        /// <summary>
        /// 返回指定key的 bool 类型的值，如果不存在 则返回输入的缺省值(默认false)
        /// </summary>
        /// <param name="section">指定的域。</param>
        /// <param name="key">key</param>
        /// <param name="defaultValue">如果key不存在时的返回的缺省值。</param>
        /// <returns></returns>
        public bool GetBoolean(string section, string key, bool defaultValue = false)
        {
            try
            {
                return GetString(section, key, "false")?.ToLower() == "true";
            }
            catch { }
            return defaultValue;
        }

        #endregion

        #region 添加了一个静态对象及一系列静态方法，方便于直接使用而不需要再定义。
        static ConfigAccess ca = new ConfigAccess("config.ini");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void WriteValue(string key, string value, string section = "Others")
        {
            ca.SetValue(section, key, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public static string ReadValue(string key, string section = "Others")
        {
            return ca.GetString(section, key);
        }
        #endregion
    }
}
