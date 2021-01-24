            // You will need to ensure these are right
            List<string> fields = new List<string>();
            DataTable data = new DataTable();
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
                DataRow currentRow = data.NewRow();
                foreach (var field in fields)
                {
                    XmlNode objNode = item.SelectSingleNode("//FL[@val='" + field + "']");
                    if (objNode != null)
                    {
                        string value = objNode.InnerText;
                        currentRow[field] = value;
                    }
                }
                data.Rows.Add(currentRow);
            }
            data.AcceptChanges();
