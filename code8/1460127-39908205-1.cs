    [TestClass]
    public class MyControllerTests {
        [TestMethod]
        public void PostAction_Should_Receive_Json_Data() {
            //Arrange
            //create a fake stream of data to represent request body
            var json = "{ \"Key\": \"Value\"}";
            var bytes = System.Text.Encoding.UTF8.GetBytes(json.ToCharArray());
            var stream = new MemoryStream(bytes);
            //create a fake http context to represent the request
            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.Setup(m => m.Request.InputStream).Returns(stream);
            var sut = new MyController();
            //Set the controller context to simulate what the framework populates during a request
            sut.ControllerContext = new ControllerContext {
                Controller = sut,
                HttpContext = mockHttpContext.Object
            };
            //Act
            var result = sut.PostAction();
            //Assert
            Assert.AreEqual(json, result.Model);
        }
        public class MyController : Controller {
            [HttpPost]
            public ActionResult PostAction() {
                string json = new StreamReader(Request.InputStream).ReadToEnd();
                //do something with json
                //returning json as model just to prove it received the data
                return View((object)json);
            }
        }
    }
