    [TestClass]
    public class ErrorControllerTests {
        [TestMethod]
        public void TestIndexView() {
            //Arrange
            var expectedViewName = GetViewNameFromExpression<ErrorController>(c => c.Index());
            var controller = ArrangeErrorController(expectedViewName);
            //Act
            var result = controller.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
            //Replicating Framework functionality
            MockExecuteResult(controller, result);
            Assert.AreEqual(expectedViewName, result.ViewName);
            CollectionAssert.AreEquivalent(controller.ViewData.ToList(), result.ViewData.ToList());
            CollectionAssert.AreEquivalent(controller.TempData.ToList(), result.TempData.ToList());
        }
        private static void MockExecuteResult(ErrorController controller, ViewResult result) {
            try {
                result.View = Mock.Of<IView>();
                result.ExecuteResult(controller.ControllerContext);
            } catch { }
        }
        private static ErrorController ArrangeErrorController(string actionName) {
            var controllerName = "error";
            var context = GetControllerContext(actionName, controllerName);
            var controller = new ErrorController() {
                ControllerContext = context
            };
            context.Controller = controller;
            return controller;
        }
        private static ControllerContext GetControllerContext(string actionName, string controllerName) {
            RouteData rd = new RouteData();
            rd.Values["action"] = actionName;
            rd.Values["controller"] = controllerName;
            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.Setup(c => c.Session).Returns((HttpSessionStateBase)null);
            mockHttpContext.Setup(_ => _.Response.Output).Returns(new StringWriter());
            return new ControllerContext(mockHttpContext.Object, rd, new Mock<Controller>().Object);
        }
        private static string GetViewNameFromExpression<TController>(Expression<Action<TController>> action) {
            if (action == null) {
                throw new ArgumentNullException("action");
            }
            var type = typeof(TController);
            bool isController = type != null
                   && type.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)
                   && !type.IsAbstract
                   && typeof(IController).IsAssignableFrom(type);
            if (!isController) {
                throw new InvalidOperationException("Invalid controller.");
            }
            MethodCallExpression body = action.Body as MethodCallExpression;
            if (body == null)
                throw new InvalidOperationException("Expression must be a method call.");
            if (body.Object != action.Parameters[0])
                throw new InvalidOperationException("Method call must target lambda argument.");
            string actionName = body.Method.Name;
            return actionName;
        }
    }
