    [TestMethod]
    public void MyTestMethod()
    {
        using (ShimsContext.Create())
        {
            // fake assembly will have a long method name for the signature of the call. omitted for simplicity
            ShimTWCProxy.GetCurrentCondition[...] = () => {throw new Exception("message")};
     
            // instantiate and execute test code
            var logger = new Mock<IExceptionLogger>();
            var testedClass = new WeatherChannelWrapper (logger.Object);
            testedClass.GetLocalWeather("...");
            svc.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
    
        }
    }
