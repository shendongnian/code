    public void ExampleNewsControllerTest() {
        //Arrange
        var getNews = RegisterDependencies.container.Resolve<IGetNews>();//OR Mock
        var addNews = RegisterDependencies.container.Resolve<IAddNews>();//OR Mock;
        var log = RegisterDependencies.container.Resolve<ILoggingService>();//OR Mock;
    
        var subject = new NewsController(getNews, addNews, log);
    
        //Act
        //...exercise the method under test
        subject.SomeAction();
    
        //Assert
        //...assert that the subject behaves as expected.
    
    }
