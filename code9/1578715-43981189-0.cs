    public string GetRequest(string url)
    {
        using (HttpResponseMessage response = client.GetAsync(url).Result)
        {
            var byteArray = response.Content.ReadAsByteArrayAsync().Result;
            var result = Encoding.GetEncoding("ISO-8859-1").GetString(byteArray, 0, byteArray.Length);
            return result;
        }
    }
