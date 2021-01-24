    _server = new TestServer(new WebHostBuilder()
        .UseStartup<Startup>());
    _client = _server.CreateClient();
    
    var content = new StringContent($"username={_username}&password={_password}",
        Encoding.UTF8,
        "application/x-www-form-urlencoded");
    HttpResponseMessage response = await _client.PostAsync("foo_path", content);
