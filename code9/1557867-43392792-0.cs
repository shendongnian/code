    _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
    _client = _server.CreateClient();
    // Pass a not valid model 
    var response = await _client.PostAsJsonAsync("Track", new DataItem());
    Assert.IsFalse(response.IsSuccessStatusCode);
