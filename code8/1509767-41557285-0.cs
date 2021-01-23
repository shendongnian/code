    public static void ReplaceCode()
         {
            var root = XElement.Load(@"C:\data.xml");
            foreach (var e in root.Descendants("alternateID"))
            {
                if (!e.Attribute("code").Value.Equals("ALT")) continue;
                e.Value = "00000000";
                break;
            }
            root.Save(@"C:\data.xml");
        }
