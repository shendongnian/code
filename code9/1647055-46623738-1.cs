    private bool CheckConnection(String URL)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Timeout = 5000;
            request.Credentials = CredentialCache.DefaultNetworkCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    
            return response.StatusCode == HttpStatusCode.OK;
        }
        catch
        {
            return false;
        }
    }
