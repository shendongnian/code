    [TestClass]
    public class ErrorControllerTests {
        [TestMethod]
        public void IndexViewTest() {
            //Arrange
            var expectedViewName = "index";
            var controllerName = "error";
            var context = GetControllerContext(expectedViewName, controllerName);
            var controller = new ErrorController() {
                ControllerContext = context
            };
            context.Controller = controller;
            //Act
            var result = controller.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
            //Replicating Framework functionality but
            //This is expected to fail as the view enginge is not setup in unit tests.
            //It does how ever get the view name from the action before trying to
            //render it in the non existent view engine.
            try {
                result.ExecuteResult(context);
            } catch { }
            Assert.AreEqual(expectedViewName, result.ViewName);  
        }
        //...Other tests would follow the same format
        private static ControllerContext GetControllerContext(string actionName, string controllerName) {
            RouteData rd = new RouteData();
            rd.Values["action"] = actionName;
            rd.Values["controller"] = controllerName;
            Mock<HttpContextBase> mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.Setup(c => c.Session).Returns((HttpSessionStateBase)null);
            return new ControllerContext(mockHttpContext.Object, rd, new Mock<Controller>().Object);
        }
    }
