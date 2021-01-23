    var client = new HttpClient();
     
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
        "Basic",
        Convert.ToBase64String(
            Encoding.ASCII.GetBytes(
                string.Format("{0}:{1}", Uri.EscapeDataString(oauth_consumer_key),
                              Uri.EscapeDataString(oauth_consumer_secret)))));
     
    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip");
    client.DefaultRequestHeaders.TryAddWithoutValidation("Host", "api.twitter.com");
     
    var content = new StringContent(postBody);
    content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
    HttpResponseMessage response =await client.PostAsync(oauth_url, content);
    response.EnsureSuccessStatusCode();
     
    using (var responseStream = response.Content.ReadAsStreamAsync())
    using (var decompressedStream = new GZipStream(responseStream.Result, CompressionMode.Decompress))
    using (var streamReader = new StreamReader(decompressedStream))
    {
    var rawJWt = streamReader.ReadToEnd();
    var jwt = JsonConvert.DeserializeObject(rawJWt);
    }
