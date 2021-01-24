    [TestClass]
    public class UnitTest6 {
        [TestMethod]
        public async Task Action_Returns_AnonymousTypeResult() {
            //Arrange
            var controller = new SearchController() {
                Configuration = new HttpConfiguration(),
                Request = new HttpRequestMessage()
            };
            var expected = "hello world";
            //Act
            var result = await controller.InitiateAsync();
            var response = await result.ExecuteAsync(CancellationToken.None);
            var status = await response.Content.ReadAsAsync<dynamic>();
            //Assert
            Assert.IsNotNull(status.sessionId);
            Assert.AreEqual(expected, status.sessionId);
        }
        [Authorize]
        public class SearchController : ApiController {
            [HttpPost]
            public async Task<IHttpActionResult> InitiateAsync() {
                string sessionId = await Task.FromResult("hello world");
                return Ok(new { sessionId });
            }
        }
    }
