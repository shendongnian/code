    [TestClass]
    public class UrlHelperTest {
        [TestMethod]
        public void MockUrlHelper() {
            //Arrange
            var requestUrl = new Uri("http://myrequesturl");
            var request = Mock.Of<HttpRequestBase>();
            var requestMock = Mock.Get(request);
            requestMock.Setup(m => m.Url).Returns(requestUrl);
            var httpcontext = Mock.Of<HttpContextBase>();
            var httpcontextSetup = Mock.Get(httpcontext);
            httpcontextSetup.Setup(m => m.Request).Returns(request);
            var actionName = "MyTargetActionName";
            var expectedUrl = "http://myfakeactionurl.com";
            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper
                .Setup(m => m.Action(actionName, "Register", It.IsAny<object>(), It.IsAny<string>()))
                .Returns(expectedUrl)
                .Verifiable();
            var sut = new MyController();
            sut.Url = mockUrlHelper.Object;
            sut.ControllerContext = new ControllerContext {
                Controller = sut,
                HttpContext = httpcontext,
            };
            //Act
            var result = sut.MyAction();
            //Assert
            mockUrlHelper.Verify();
        }
        public class MyController : Controller {
            [HttpPost]
            public ActionResult MyAction() {
                var link = GenerateActionLink("MyTargetActionName", string.Empty, string.Empty);
                return View((object)link);
            }
            private string GenerateActionLink(string actionName, string token, string username) {
                string validationLink = null;
                if (Request.Url != null) {
                    var encodedToken = EncodedUrlParameter(token);
                    var url = Url.Action(actionName, "Register", new { Token = encodedToken, Username = username }, Request.Url.Scheme);
                    validationLink = url;
                }
                return validationLink;
            }
            private string EncodedUrlParameter(string token) {
                return "Fake encoding";
            }
        }
    }
