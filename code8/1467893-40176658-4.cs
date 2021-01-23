    [TestClass]
    public class IntegrationTests {
        [TestMethod]
        public async Task Test() {
            using (var server = HttpTestServer.Create()) {
                //Arrange
                var config = server.Configuration;
                //Config server
                MyWebApiNamespace.WebApiConfig.Register(config);
                var client = server.CreateClient();
                var url = "http://localhost/test";
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var expected = System.Net.HttpStatusCode.OK;
                //Act
                var result = await client.SendAsync(request, CancellationToken.None);
                //Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(expected, result.StatusCode);
            }
        }
    }
