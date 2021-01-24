       string body = File.ReadAllText(@"D:\json.txt");
                // Display the file contents to the console. Variable text is a string.
                string tenantId = "tenantId";
                string clientId = "clientId(applicationid)";
                string clientSecret = "applicationSecret";
                string subscription = "subscriptionId";
                string resourcegroup = "Youresourcegroup";
        
                string authContextURL = "https://login.windows.net/" + tenantId;
                var authenticationContext = new AuthenticationContext(authContextURL);
                var credential = new ClientCredential(clientId, clientSecret);
                var result = authenticationContext.AcquireTokenAsync(resource: "https://management.azure.com/", clientCredential: credential).Result;
                if (result == null)
                {
                    throw new InvalidOperationException("Failed to obtain the JWT token");
                }
                string token = result.AccessToken;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(string.Format("https://management.azure.com/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Resources/deployments/Microsoft.Relay?api-version=2016-07-01", subscription, resourcegroup));
                request.Method = "PUT";
                request.Headers["Authorization"] = "Bearer " + token;
                request.ContentType = "application/json";
    
                try
                {
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(body);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //Get the response
                var httpResponse = (HttpWebResponse)request.GetResponse();
                Console.WriteLine(httpResponse.StatusCode);
    
                Console.ReadLine();
