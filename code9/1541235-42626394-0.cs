    [TestClass]
    public class CustomExcpetionhandlerUnitTests {
        [TestMethod]
        public void ShouldHandleException() {
            //Arrange
            var sut = new CustomExceptionHandler();
            var exception = new Exception("Hello World");
            var catchblock = new ExceptionContextCatchBlock("webpi", true, false);
            var configuration = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/test");
            request.SetConfiguration(configuration);
            var exceptionContext = new ExceptionContext(exception, catchblock, request);
            var context = new ExceptionHandlerContext(exceptionContext);
            
            Assert.IsNull(context.Result);
            //Act
            sut.Handle(context);
            //Assert
            Assert.IsNotNull(context.Result);
        }
    }
