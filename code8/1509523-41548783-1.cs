    public async Task LoginUser(string userName, string password)
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri(url)
        };
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var model = new UserModel
        {
            UserName = userName,
            UserPassword = password
        };
        var userModel = JsonConvert.SerializeObject(model);
        var content = new StringContent(userModel, Encoding.UTF8, "application/json");
        await GetUserTask(_client, content);
    }
