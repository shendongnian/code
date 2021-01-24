    WebClient webClient = new WebClient();
    webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                
    string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
                
    webClient.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
                
    string jsonOutput = JsonConvert.SerializeObject(new Issue(Title, Description), Formatting.Indented);
    
    string response = webClient.UploadString(repoIssueLink, jsonOutput);
    Console.WriteLine(response);
    Console.WriteLine(jsonOutput);
