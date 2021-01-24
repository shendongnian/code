    public async void MakeRequest()
    {
        var http = new HttpClient();
        var response = await http.GetAsync(ServerUrls.serverUrl);
        response.EnsureStatusSuccessCode(); //Throws an exception if status code isn't 200.
        var html = await response.Content.ReadAsStringAsync();
    }
