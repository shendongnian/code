    private string BigCommerceGet(string URL)
    {
        System.Net.HttpWebRequest req = (HttpWebRequest)WebRequest.Create(baseUrl + URL);
        req.Credentials = new NetworkCredential(_username, _api_key);
        req.AllowAutoRedirect = true;
        req.ContentType = "application/json";
        req.Accept = "application/json";
        req.Method = "GET";
    
        string jsonResponse = null;
        using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
        {
            if (req.HaveResponse && resp != null)
            {
                using (var reader = new StreamReader(resp.GetResponseStream()))
                {
                    jsonResponse = reader.ReadToEnd();
                }
            }
        }
    
        return jsonResponse;
    }
