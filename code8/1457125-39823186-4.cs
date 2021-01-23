    [TestMethod]
    public async Task Change_OWIN_Request_Body_To_WebApi_Test() {
        var encryptedContent = "Hello World";
        var expectedResponse = "\"I am working\"";
        using (var server = TestServer.Create<Startup2>()) {
                                       
            var content = new StringContent(encryptedContent, Encoding.UTF8, "application/json");
            var response = await server.HttpClient.PostAsync("api/Test", content);
            var result = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(expectedResponse, result);
        }
    }
