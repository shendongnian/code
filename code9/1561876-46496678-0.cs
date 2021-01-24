    public async void  TestHttpClient()
    { 
        var client = new HttpClient();
        var credentials = Encoding.ASCII.GetBytes("user:xxxxx");
        var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
        client.DefaultRequestHeaders.Authorization = header;
        String url = "http://my_url:port/write?db=myDb";
        String content = "FieldName,host=M.233 value=52.666 timestamp"
        StringContent stringContent = new StringContent(content);
        var result = await client.PostAsync(url, stringContent);
    }
