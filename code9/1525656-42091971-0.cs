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
