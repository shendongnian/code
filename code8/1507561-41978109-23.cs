    [TestClass]
    public class UnifiedErrorMessageTests {
        [TestMethod]
        public async Task _OWIN_Response_Should_Pass_When_Ok() {
            //Arrange
            var message = "\"Hello World\"";
            var expectedResponse = "\"I am working\"";
            using (var server = TestServer.Create<WebApiTestStartup>()) {
                var client = server.HttpClient;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(message, Encoding.UTF8, "application/json");
                //Act
                var response = await client.PostAsync("/api/Foo", content);
                //Assert
                Assert.IsTrue(response.IsSuccessStatusCode);
                var result = await response.Content.ReadAsStringAsync();
                Assert.AreEqual(expectedResponse, result);
            }
        }
        [TestMethod]
        public async Task _OWIN_Response_Should_Be_Unified_When_BadRequest() {
            //Arrange
            var expectedResponse = "invalid_grant";
            using (var server = TestServer.Create<WebApiTestStartup>()) {
                var client = server.HttpClient;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(expectedResponse, Encoding.UTF8, "application/json");
                //Act
                var response = await client.PostAsync("/api/Foo", content);
                //Assert
                Assert.IsFalse(response.IsSuccessStatusCode);
                var result = await response.Content.ReadAsAsync<dynamic>();
                Assert.AreEqual(expectedResponse, (string)result.error_description);
            }
        }
        [TestMethod]
        public async Task _OWIN_Response_Should_Be_Unified_When_MethodNotAllowed() {
            //Arrange
            var expectedResponse = "Method Not Allowed";
            using (var server = TestServer.Create<WebApiTestStartup>()) {
                var client = server.HttpClient;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Act
                var response = await client.GetAsync("/api/Foo");
                //Assert
                Assert.IsFalse(response.IsSuccessStatusCode);
                var result = await response.Content.ReadAsAsync<dynamic>();
                Assert.AreEqual(expectedResponse, (string)result.error);
            }
        }
        [TestMethod]
        public async Task _OWIN_Response_Should_Be_Unified_When_NotFound() {
            //Arrange
            var expectedResponse = "Not Found";
            using (var server = TestServer.Create<WebApiTestStartup>()) {
                var client = server.HttpClient;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Act
                var response = await client.GetAsync("/api/Bar");
                //Assert
                Assert.IsFalse(response.IsSuccessStatusCode);
                var result = await response.Content.ReadAsAsync<dynamic>();
                Assert.AreEqual(expectedResponse, (string)result.error);
            }
        }
        public class WebApiTestStartup {
            public void Configuration(IAppBuilder app) {
                app.UseCommonErrorMessageMiddleware();
                var config = new HttpConfiguration();
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
                app.UseWebApi(config);
            }
        }
        public class FooController : ApiController {
            public FooController() {
            }
            [HttpPost]
            public IHttpActionResult Bar([FromBody]string input) {
                if (input == "Hello World")
                    return Ok("I am working");
                return BadRequest("invalid_grant");
            }
        }
    }
