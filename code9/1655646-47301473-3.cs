    public SettingsTests()
    {
      TestServer = new ApiTestServer();
      HttpClient = TestServer.CreateClient();
    }
