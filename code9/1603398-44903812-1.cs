    // Arrange
    var personAppClientMock = new Mock<IAppClient>();
    personAppClientMock.Setup(_ => _.AddAsync(It.IsAny<ExpandoObject>()))
                       .ReturnsAsync(User);
    var notificationsClientMock = new Mock<IAppClient>();
    notificationsClientMock.Setup(_ => _.AddAsync(It.IsAny<ExpandoObject>()))
                           .ReturnsAsync(SomeOtherObject);
    //...other related setup code
    var sut = new AccountController(
                      rulesFacadeMock.Object, 
                      personAppClientMock.Object, 
                      notificationsClientMock.Object, 
                      transformerMock.Object);
    // Act
    //...
