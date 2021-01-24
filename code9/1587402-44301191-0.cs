     public ILoggingService ReturnMockLoggingService()
     {
           var mockService = new Mock<ILoggingService>();
           return mockService.Object;
     }
