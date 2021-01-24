    public void ExampleNewsControllerTest() {
        //Arrange
        var getNews = Mock.Of<IGetNews>();
        var addNews = Mock.Of<IAddNews>();
        var log = Mock.Of<ILoggingService>();
    
        var subject = new NewsController(getNews, addNews, log);
    
        //Act
        //...exercise the method under test
        subject.SomeAction();
    
        //Assert
        //...assert that the subject behaves as expected.
    
    }
