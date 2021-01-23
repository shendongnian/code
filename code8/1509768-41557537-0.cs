    public static void ReplaceCode()
         {
            var root = new XmlDocument();
             root.Load(@"C:\data.xml");
            foreach (XmlNode e in root.GetElementsByTagName("alternateID"))
            {
                if (e.Attributes["code"].Value.Equals("ALT"))
                {
                    e.FirstChild.Value = "00000000"; // FirstChild because the inner node is actually the inner text, yeah XmlNode is weird.
                    break;
                }
            }
            root.Save(@"C:\data.xml");
        }
