     [TestMethod]
     public async Task HasHeader()
      {
        using (var server = TestServer.Create(app =>
        {
            //need to set header before calling the below middleware header name is bobsyouruncle
            app.Use(typeof(TestMiddleware));
            app.Use(typeof(HeaderMiddleware));
        }))
        using (var client = new HttpClient(server.Handler))
        {
            var response = await client.GetAsync("http://win.example.com/bob/");
            System.Diagnostics.Debugger.Break();
        }
    }
