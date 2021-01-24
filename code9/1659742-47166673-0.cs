    var credential = new NetworkCredential(userName_SP, password_SP, domain_SP);
    var myCache = new CredentialCache();
    myCache.Add(new Uri(core_URL), "NTLM", credential);
    var handler = new HttpClientHandler();
    handler.AllowAutoRedirect = true;
    handler.Credentials = myCache;
    using (var client_sharePoint = new HttpClient(handler))
    {
        client_sharePoint.BaseAddress = uri;
        client_sharePoint.DefaultRequestHeaders.Accept.Clear();
        client_sharePoint.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        var response = await client_sharePoint.GetAsync(core_URL);
        var responsedata = await response.Content.ReadAsStringAsync();
        var returnObj = JsonConvert.DeserializeObject<SharepointDTO.RootObject>(
            responsedata);
        return returnObj;
    }
