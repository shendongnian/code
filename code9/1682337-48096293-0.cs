    public async Task<HttpResponseMessage> DataDownloadFile(string srcFilePath)
    {
        string DownloadUrl = "https://{0}.azuredatalakestore.net/webhdfs/v1/{1}?op=OPEN&read=true";
        var fullurl = string.Format(DownloadUrl, _datalakeAccountName, srcFilePath);
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accesstoken.access_token);
            using (var formData = new MultipartFormDataContent())
            {
                resp = await client.GetAsync(fullurl);
            }
        }
        return resp;
    }
