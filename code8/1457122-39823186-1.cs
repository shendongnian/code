    [TestMethod]
    public async Task Change_OWIN_Request_Body_Test() {
        var encryptedContent = "Hello World";
        var expectedResponse = "I am working";
        using (var server = TestServer.Create<Startup1>()) {
            var content = new StringContent(encryptedContent);
            var response = await server.HttpClient.PostAsync("/", content);
            var result = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(expectedResponse, result);
        }
    }
    public class Startup1 {
        public void Configuration(IAppBuilder appBuilder) {
            var encryptedContent = "Hello World";
            var decryptedString = "Hello OWIN";
            var expectedResponse = "I am working";
            appBuilder.Use<DecryptionMiddleWare>(encryptedContent, decryptedString);
            appBuilder.Use<AnotherCustomMiddleWare>(decryptedString, expectedResponse);
        }
    }
