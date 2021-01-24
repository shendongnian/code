    string asbUri = 
        "https://<azurenamespace>.servicebus.windows.net/<topicname>/messages";
    TimeSpan ts = new TimeSpan(0, 0, 90);
    string sasToken = GetSASToken("sb://<azurenamespace>.servicebus.windows.net", " 
        <nameofSASkey>", "<SASKeyValue>", ts);
    HttpClient client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", sasToken);
    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, asbUri)
    {
        Content = new StringContent(json, Encoding.UTF8, "application/json")
    };
    HttpResponseMessage response = client.SendAsync(request).Result;
    private static string GetExpiry(TimeSpan ttl)
    {
       TimeSpan expirySinceEpoch = DateTime.UtcNow - new DateTime(1970, 1, 1) + ttl;
       return Convert.ToString((int)expirySinceEpoch.TotalSeconds);
    }
    public static string GetSASToken(string resourceUri, string keyName, string key, 
    TimeSpan ttl)
    {
       var expiry = GetExpiry(ttl);
       //string stringToSign = HttpUtility.UrlEncode(resourceUri) + "\n" + expiry;
       //NOTE: UrlEncode is not supported in CRM, use System.Uri.EscapeDataString instead
       string stringToSign = Uri.EscapeDataString(resourceUri).ToLowerInvariant() + "\n" 
            + expiry;
            HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
       var signature = 
       Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
       var sasToken = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature 
           sr={0}&sig={1}&se={2}&skn={3}",
           Uri.EscapeDataString(resourceUri).ToLowerInvariant(), 
           Uri.EscapeDataString(signature), expiry, keyName);
       return sasToken;
    }
