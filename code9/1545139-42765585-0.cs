            string filename = "01.xml";
            XmlDocument xdc = new XmlDocument();
            xdc.Load(filename);
            XmlNodeList xnlNodes = xdc.SelectNodes("command");
            foreach (XmlNode xnlNode in xnlNodes)
            {
                XmlElement element = (XmlElement)xnlNode;
                string Name = Convert.ToString(xnlNode["Name"].InnerText);
                int[] data = new int[]
                    {
     Convert.ToInt32(element.GetElementsByTagName("data")[0].ChildNodes[0].InnerText),
     Convert.ToInt32(element.GetElementsByTagName("data")[0].ChildNodes[1].InnerText),
     Convert.ToInt32(element.GetElementsByTagName("data")[0].ChildNodes[2].InnerText)
                    };
                int[] rangeData = new int[]
                    {
     Convert.ToInt32(element.GetElementsByTagName("rangeData")[0].ChildNodes[0].InnerText),
     Convert.ToInt32(element.GetElementsByTagName("rangeData")[0].ChildNodes[1].InnerText),
     Convert.ToInt32(element.GetElementsByTagName("rangeData")[0].ChildNodes[2].InnerText)
                    };
            }
