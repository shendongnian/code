    using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(JiraPath);
                    // Add an Accept header for JSON format.
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    string mergedCreds = string.Format("{0}:{1}", username, password);
    byte[] byteCreds = UTF8Encoding.UTF8.GetBytes(mergedCreds);
                    var authHeader = new AuthenticationHeaderValue("Basic", byteCreds);
                    client.DefaultRequestHeaders.Authorization = authHeader;
                    HttpResponseMessage response = client.GetAsync(restURL).Result;  // Blocking call!
                    if (response.IsSuccessStatusCode)
                    {
                        strJSON = response.Content.ReadAsStringAsync().Result;
                        if (!string.IsNullOrEmpty(strJSON))
                            return strJSON;
                    }
                    else
                    {
                        exceptionOccured = true;
                        // Use "response.ReasonPhrase" to return error message
                        
                    }
                }
