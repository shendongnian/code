    private async void DummyRequest()
    {
        HttpClient client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
        int id1 = 1;
        int id2 = 2;
        int id3 = 3;
        HttpResponseMessage xResp = await client.GetAsync($"http://localhost:52089/api/test?id1={id1}&id2={id2}&id3={id3}");
    }
