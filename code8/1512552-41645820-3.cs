    [TestClass]
    public class MyControllerTests {
        [TestMethod]
        public void Request_Cookies_Should_Not_Be_Null() {
            //Arrange
            var cookies = new HttpCookieCollection();
            cookies.Add(new HttpCookie("usercookie"));
            var mockHttpContext = new MockHttpContext(cookies);
            
            var sut = new MyController();
            sut.ControllerContext = new ControllerContext {
                Controller = sut,
                HttpContext = mockHttpContext
            };
            //Act
            var result = sut.Dashboard() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        public class MyController : Controller {
            public ActionResult Dashboard() {
                if (Request.Cookies["usercookie"] == null) {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
        private class MockHttpContext : HttpContextBase {
            private readonly MockRequest request;
            public MockHttpContext(HttpCookieCollection cookies) {
                this.request = new MockRequest(cookies);
            }
            public override HttpRequestBase Request {
                get {
                    return request;
                }
            }
            public class MockRequest : HttpRequestBase {
                private readonly HttpCookieCollection cookies;
                public MockRequest(HttpCookieCollection cookies) {
                    this.cookies = cookies;
                }
                public override HttpCookieCollection Cookies {
                    get {
                        return cookies;
                    }
                }
            }
        }
    }
