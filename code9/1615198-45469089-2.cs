    public class WeatherChannelWrapperTests
    {
    	[Test]
    	public void GetLocalWeather_WhenInternalExceptionOccurs_LogsException_Test()
    	{
    		var loggerMock = new Mock<IExceptionLogger>();
    		var sut = new FakeWeatherChannelWrapper(loggerMock.Object);
    		
    		sut.GetLocalWeather("12345");
    		
    		// Assert Exception is logged
    		loggerMock.Verify(logger => logger.Log(It.IsAny<Exception>()), Times.Once);
    		
    		// And practically this also tests that it doesn't crash even if exception is thrown
    	}
    }
