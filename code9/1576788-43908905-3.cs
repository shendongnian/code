            // You will need to ensure these are right
            DataTable data = new DataTable();
            List<string> fields = new List<string>()
            {
                "LEADID", "SMOWNERID", "Lead Owner", "Company", "First Name", "Last Name", "Email", "Phone", "Lead Source", "Created By", "SMCREATORID", "MODIFIEDBY", "Modified By", "Created Time", "Modified Time", "Street", "City", "State", "Zip Code", "Last Activity Time", "Lead Type", "Practice name", "SMS Opt Out", "Send SMS"
            };
            foreach (var field in fields)
            {
                DataColumn column = new DataColumn(field, typeof(String));
                data.Columns.Add(column);
            }
            
            string xmlText;
            using (var client = new WebClient())
            {
                IWebProxy defaultWebProxy = WebRequest.DefaultWebProxy;
                defaultWebProxy.Credentials = CredentialCache.DefaultCredentials;
                client.Proxy = defaultWebProxy;
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
                List<string> rowData = new List<string>();
                foreach (XmlElement node in item.ChildNodes)
                {
                    if (fields.Contains(node.Attributes["val"].Value))
                    {
                        Console.WriteLine(node.Attributes["val"].Value + ":" + node.InnerText);
                        
                        currentRow[fields.IndexOf(node.Attributes["val"].Value)] = node.InnerText;
                        
                    }
                }
                data.Rows.Add(currentRow);
            }
            data.AcceptChanges();
