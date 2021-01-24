    //Arrange
    var mock = Mock.Of<ISession>();
    BookManager.Session = () => {
        return mock;
    };
    Mock.Get(mock).Setup(_ => _.Get("Books"))
        .Returns(Encoding.UTF8.GetBytes("[{some json string here}]"));
    //Act
    var books = BookManager.GetBooks();
    //...
