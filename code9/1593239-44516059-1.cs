        string tenantId = " ";
        string clientId = " ";
        string clientSecret = " ";
        string subscription = " ";
        string resourcegroup = "BrandoSecondTest";
        string accountname = "brandofirststorage";
        string authContextURL = "https://login.windows.net/" + tenantId;
        var authenticationContext = new AuthenticationContext(authContextURL);
        var credential = new ClientCredential(clientId, clientSecret);
        var result = authenticationContext.AcquireTokenAsync(resource: "https://management.azure.com/", clientCredential: credential).Result;
        if (result == null)
        {
            throw new InvalidOperationException("Failed to obtain the JWT token");
        }
        string token = result.AccessToken;
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(string.Format("https://management.azure.com/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Storage/storageAccounts/{2}/listKeys?api-version=2016-01-01", subscription, resourcegroup, accountname));
        request.Method = "POST";
        request.Headers["Authorization"] = "Bearer " + token;
        request.ContentType = "application/json";
        request.ContentLength = 0;
      
        //Get the response
        var httpResponse = (HttpWebResponse)request.GetResponse();
        using (System.IO.StreamReader r = new System.IO.StreamReader(httpResponse.GetResponseStream()))
        {
            string jsonResponse = r.ReadToEnd();
            Console.WriteLine(jsonResponse);
        }
