    [TestClass]
    public class MyControllerTests {
        [TestMethod]
        public void Request_Cookies_Should_Not_Be_Null() {
            //Arrange
            var cookies = new HttpCookieCollection();
            cookies.Add(new HttpCookie("usercookie"));
            var mockHttpContext = Substitute.For<HttpContextBase>();
            mockHttpContext.Request.Cookies.Returns(cookies);
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
    }
