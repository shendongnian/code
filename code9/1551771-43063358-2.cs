    string body = File.ReadAllText(@"D:\json.txt");
    
                // Display the file contents to the console. Variable text is a string.
    
                string tenantId = "xxxxxxxxxxxxxxxxxxxxxxxxx";
                string clientId = "xxxxxxxxxxxxxxxxxxxxxxxxxxx";
                string clientSecret = "xxxxxxxxxxxxxxxxxxxxxxxxx";
                string subscriptionid = "xxxxxxxxxxxxxxxxxxxxxxxxxx";
                string resourcegroup = "BrandoSecondTest";
    
                string appname = "BrandoTestApp";
                string version = "2015-08-01";
    
                string authContextURL = "https://login.windows.net/" + tenantId;
                var authenticationContext = new AuthenticationContext(authContextURL);
                var credential = new ClientCredential(clientId, clientSecret);
                var result = authenticationContext.AcquireTokenAsync(resource: "https://management.azure.com/", clientCredential: credential).Result;
    
                if (result == null)
                {
                    throw new InvalidOperationException("Failed to obtain the JWT token");
                }
    
                string token = result.AccessToken;
    
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(string.Format("https://management.azure.com/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Web/sites/{2}?api-version={3}", subscriptionid, resourcegroup, appname, version));
    
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
                // Get the response
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
