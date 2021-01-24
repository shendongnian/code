    [TestClass]
    public class MyTestClass {
        private class WorkClass {
            private IWHttpClient _client;
            public WorkClass(IWHttpClient client) {
                _client = client;
            }
            public async Task DoWork() {
                var url = "DUMMY";
                var content = new ObjectToSerialize();
                var response = await _client.PostAsJsonAsync(url, content);
            }
        }
        public class ObjectToSerialize {
        }
        [TestMethod]
        public async Task MyTestMethod() {
            //Arrange
            var expectedResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            var _webClientMock = new Mock<IWHttpClient>(MockBehavior.Strict);
            _webClientMock
                .Setup(_ => _.PostAsJsonAsync(It.IsAny<string>(), It.IsAny<ObjectToSerialize>()))
                .ReturnsAsync(expectedResponse)
                .Verifiable();
            var myClassToTest = new WorkClass(_webClientMock.Object);
            //Act
            await myClassToTest.DoWork();
            //Assert
            _webClientMock.Verify();
        }
    }
