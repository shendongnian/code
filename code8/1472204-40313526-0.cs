    private NameValueCollection GetQueryStringParameters()
        {
            NameValueCollection nameValueTable = new NameValueCollection();
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                string queryString = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
                string[] querySegments = queryString.Split('&');
                foreach (string segment in querySegments)
                {
                    string[] parts = segment.Split('=');
                    if (parts.Length > 0)
                    {
                        string key = parts[0].Trim(new char[] { '?', ' ' });
                        string val = parts[1].Trim();
                        //MessageBox.Show("key=" + key + " val=" + val);
                        nameValueTable.Add(key, val);
                    }
                }
                
            }
            return (nameValueTable);
        }
                       
