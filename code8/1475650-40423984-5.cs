    [TestMethod]
    [IntegrationTest]
    public async Task HttpClient_Should_Get_OKStatus_From_InMemory_Hosting() {
        using (var server = new HttpTestServer()) {
            MyWebAPiProjectNamespace.WebApiConfig(server.Configuration);
            var client = server.CreateClient();
            string url = "http://localhost/prefix/10?id2=5";
            var expected = 15;
            var request = new HttpRequestMessage {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var response = await client.SendAsync(request)) {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                var result = await response.Content.ReadAsAsync<int>();
                Assert.AreEqual(expected, result);
            }
        }
    }
