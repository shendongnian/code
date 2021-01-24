     public static List<String> getSqlDatabaseList()
            {
                //System.Diagnostics.Debug.WriteLine("Starting to get database list");
                List<string> dbNameList = new List<string>();
    
                string tenantId = "yourtenantid";
                string clientId = "yourclientId";
                string clientSecret = "clientSecret";
                string subscriptionid = "subscriptionid";
                string resourcegroup = "resourcegroupname";
    
                string sqlservername = "brandotest";
                string version = "2014-04-01";
    
                string authContextURL = "https://login.windows.net/" + tenantId;
                var authenticationContext = new AuthenticationContext(authContextURL);
                var credential = new ClientCredential(clientId, clientSecret);
                var result = authenticationContext.AcquireToken(resource: "https://management.azure.com/", clientCredential: credential);
    
                if (result == null)
                {
                    throw new InvalidOperationException("Failed to obtain the JWT token");
                }
    
                string token = result.AccessToken;
    
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(string.Format("https://management.azure.com/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/databases?api-version={3}", subscriptionid, resourcegroup, sqlservername, version));
    
                request.Method = "GET";
                request.Headers["Authorization"] = "Bearer " + token;
    
    
                request.ContentType = "application/json";
    
    
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string jsonResponse = streamReader.ReadToEnd();
    
                    dynamic json = JsonConvert.DeserializeObject(jsonResponse);
    
                    dynamic resultList = json.value.Children();
    
    
                    foreach (var item in resultList)
                    {
                        
                        dbNameList.Add(((Newtonsoft.Json.Linq.JValue)item.name).Value.ToString());
                    }
                }
    
    
                return dbNameList;
            }
