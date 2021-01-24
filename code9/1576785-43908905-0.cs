            string xmlText;
            using (var client = new WebClient())
            {
                xmlText = client.DownloadString(@"https://ix-infiniti-preview.azurewebsites.net/Manage/zohotest.xml");
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlText);
            XmlNodeList xnList = xmlDoc.SelectNodes("/response/result/Leads/row");
            foreach (var row in xnList)
            {
                XmlElement item = row as XmlElement;
                Debug.WriteLine(item.Attributes["no"].Value);
            }
