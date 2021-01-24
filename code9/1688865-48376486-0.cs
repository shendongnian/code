           var claimsSection = config.GetSection("myCustomSection");
            string xml = claimsSection.SectionInformation.GetRawXml();
            System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
            xDoc.LoadXml(xml);
            System.Xml.XmlNode xList = xDoc.ChildNodes[0];
            for (int i =0; i< xList.ChildNodes.Count; i++)
            {
                foreach (System.Xml.XmlNode xNodo in xList.ChildNodes[i])
                {
                    Console.WriteLine((xNodo.Attributes[0].Value));
                }
            }
