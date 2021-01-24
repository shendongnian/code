    public interface IApplicationLogger
    {
        void LogError(Exception exception);
    }
    public class ApplicationLogger : IApplicationLogger
    {
        public void LogError(Exception exception)
        {
            //do stuff
        }
    }
    public class FooFactory
    {
        private readonly IApplicationLogger _logger;
    
        public FooFactory(IApplicationLogger logger)
        {
            _logger = logger;
        }
      
        public void CreateFooByUrl(string url) 
        {
            try 
            {
               // business logic
            }
            catch(Exception exception) 
            {
               _logger.LogError(exception);
            }
        }
    }
    
    //now for the unit test
    public void TestCreate()
    {
        //arrange
        var mockLogger = new Mock<IApplicationLogger>(MockBehavior.Strict);
        mockLogger.Setup(m => m.LogError(It.IsAny<Exception>()));
    
        var factory = new FooFactory(mockLogger.Object);
    
        //act
        factory.CreateFooByUrl("something that will cause exception");
        
    
        //assert
        mockLogger.Verify(m => m.LogError(It.IsAny<Exception>()));
    }
