            XmlDocument doc = new XmlDocument();
            doc.Load(Application.StartupPath + @"\" + args[1]);
            XmlElement el = (XmlElement)doc.SelectSingleNode("Applications");
            if (el != null)
            {
                XmlElement elem = doc.CreateElement("app");
                elem.SetAttribute("name", "name online game here");
                elem.SetAttribute("path", "123123123");
                elem.SetAttribute("icon", "test");
                el.AppendChild(elem);
            }
            doc.Save(Application.StartupPath + @"\" + args[1]);
