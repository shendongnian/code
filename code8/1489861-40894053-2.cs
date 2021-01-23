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
        [RoutePrefix("api/some-resources")]
        public class CreationController : ApiController {
            [HttpPost, HttpPostRoute("")]
            public IHttpActionResult CreateResource(CreateData input) {
                return Ok();
            }
        }
        [RoutePrefix("api/some-resources")]
        public class DisplayController : ApiController {
            [HttpGet, HttpGetRoute("")]
            public IHttpActionResult ListAllResources() {
                return Ok();
            }
            [HttpGet, HttpGetRoute("{publicKey:guid}")]
            public IHttpActionResult ShowSingleResource(Guid publicKey) {
                return Ok();
            }
        }
        public class CreateData { }
        class HttpGetRouteAttribute : MethodConstraintedRouteAttribute {
            public HttpGetRouteAttribute() : this("") { }
            public HttpGetRouteAttribute(string template) : base(template, HttpMethod.Get) { }
        }
        class HttpPostRouteAttribute : MethodConstraintedRouteAttribute {
            public HttpPostRouteAttribute() : this("") { }
            public HttpPostRouteAttribute(string template) : base(template, HttpMethod.Post) { }
        }
        class MethodConstraintedRouteAttribute : RouteFactoryAttribute {
            public MethodConstraintedRouteAttribute(string template, HttpMethod method)
                : base(template) {
                Method = method;
            }
            public HttpMethod Method {
                get;
                private set;
            }
            public override IDictionary<string, object> Constraints {
                get {
                    var constraints = new HttpRouteValueDictionary();
                    constraints.Add("method", new MethodConstraint(Method));
                    return constraints;
                }
            }
        }
        class MethodConstraint : IHttpRouteConstraint {
            public HttpMethod Method { get; private set; }
            public MethodConstraint(HttpMethod method) {
                Method = method;
            }
            public bool Match(HttpRequestMessage request,
                              IHttpRoute route,
                              string parameterName,
                              IDictionary<string, object> values,
                              HttpRouteDirection routeDirection) {
                return request.Method == Method;
            }
        }
    }
