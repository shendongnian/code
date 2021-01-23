    [TestMethod]
    public async Task GetEmpMethod()
    {
        var config = new HttpConfiguration();
        //configure web api
        config.Services.Replace(typeof(IAssembliesResolver), new TestWebApiResolver());
        config.MapHttpAttributeRoutes();
        using (var server = new HttpServer(config))
        {
            // arrange
            var client = new HttpClient(server);
            string url = "http://test/api/Employee";
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // act
            var result = await client.SendAsync(request);
            // assert
            result.EnsureSuccessStatusCode();
            Employee actual = await result.Content.ReadAsAsync<Employee>();
            ... assert on the actual employee instance here            
        }
    }
