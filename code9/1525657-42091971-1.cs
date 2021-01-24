      public static void DoStuff()
        {
            var stringXml = @"<messageTags> 
                                    <tag key=""35"" value=""U1"" />
                                    <tag key=""49"" value=""GEMI1"" />
                                    <tag key=""8"" value=""FIX.4.1"" />
                                    <tag key=""9"" value=""732"" />
                           </messageTags>";
            XmlDocument xmltest = new XmlDocument();
            xmltest.LoadXml(stringXml);
            XmlNodeList elemlist = xmltest.GetElementsByTagName("messageTags");
            var dic = XmlNodeListToDictionaryByAttribute("key", "value", elemlist);
            var test = DictToString(dic, "{0}={1}");
        }
        public static Dictionary<string, string> XmlNodeListToDictionaryByAttribute(string keyAttribute, string valueAttribute, XmlNodeList elemlist)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (XmlNode item in elemlist)
            {
                foreach (XmlNode childNode in item.ChildNodes)
                {
                    var dictKey = childNode.Attributes[keyAttribute].Value;
                    var dictVal = childNode.Attributes[valueAttribute].Value;
                    dict.Add(dictKey, dictVal);
                }
            }
            return dict;
        }
        public static string DictToString<T>(IDictionary<string, T> items, string format)
        {
            format = String.IsNullOrEmpty(format) ? "{0}='{1}' " : format;
            StringBuilder itemString = new StringBuilder();
            foreach (var item in items)
                itemString.AppendFormat(format, item.Key, item.Value);
            return itemString.ToString();
        }
