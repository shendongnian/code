        [TestMethod]
        public async Task TestMethod1()
        {
            const string content = @"<root><test>1243</test></root>";
            const string httpExample = "http://example.org/test/";
            var configurationManager = new Mock<IConfigurationManager>();
            
            configurationManager
                .Setup(cm => cm.GetAppSetting("ApiUrl"))
                .Returns(httpExample);
            var fakeResponseHandler = new FakeResponseHandler();
            fakeResponseHandler.AddFakeResponse(new Uri(httpExample),
                new HttpResponseMessage(HttpStatusCode.OK), content, true);
            using (var httpClient = new HttpClient(fakeResponseHandler))
            {
                var ourService = new CallingService(httpClient, configurationManager.Object);
                var result = await ourService.TransmitToApi(content);
                Assert.AreEqual(content, result.Item(0)?.OuterXml);
            }
        }
