    [TestClass]
    public class WebApiRouteTests {
        [TestMethod]
        public async Task Multiple_controllers_with_same_URL_routes_but_different_HTTP_methods() {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            var errorHandler = config.Services.GetExceptionHandler();
            var handlerMock = new Mock<IExceptionHandler>();
            handlerMock
                .Setup(m => m.HandleAsync(It.IsAny<ExceptionHandlerContext>(), It.IsAny<System.Threading.CancellationToken>()))
                .Callback<ExceptionHandlerContext, CancellationToken>((context, token) => {
                    var innerException = context.ExceptionContext.Exception;
                    Assert.Fail(innerException.Message);
                });
            config.Services.Replace(typeof(IExceptionHandler), handlerMock.Object);
            using (var server = new HttpTestServer(config)) {
                string url = "http://localhost/api/some-resources/";
                var client = server.CreateClient();
                client.BaseAddress = new Uri(url);
                using (var response = await client.GetAsync("")) {
                    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                }
                using (var response = await client.GetAsync("3D6BDC0A-B539-4EBF-83AD-2FF5E958AFC3")) {
                    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                }
                using (var response = await client.PostAsJsonAsync("", new CreateData())) {
                    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                }
            }
        }
        public class CreateData { }
    }
