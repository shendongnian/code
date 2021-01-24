    public static void Main (string[] args)
    {
        string url = "https://dashboard.reviewpush.com/api/company/locations";
    
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers["X-Api-Key"] = "key";
            client.Headers["X-Api-Secret"] = "secret";
    
            string s = client.DownloadString(url);
            Console.WriteLine(s);
        }
    }
