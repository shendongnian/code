    [TestClass]
    public class MyControllerTests {
        [TestMethod]
        public void PostAction_Should_Receive_Json_Data() {
            //Arrange
            var json = "{ \"Key\": \"Value\"}";
            var bytes = System.Text.Encoding.UTF8.GetBytes(json.ToCharArray());
            var stream = new MemoryStream(bytes);
            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.Setup(m => m.Request.InputStream).Returns(stream);
            var sut = new MyController();
            sut.ControllerContext = new ControllerContext {
                Controller = sut,
                HttpContext = mockHttpContext.Object
            };
            //Act
            var result = sut.PostAction();
            //Assert
            //...assertions here
        }
        public class MyController : Controller {
            [HttpPost]
            public ActionResult PostAction() {
                string json = new StreamReader(Request.InputStream).ReadToEnd();
                //do something with json
                return View();
            }
        }
    }
