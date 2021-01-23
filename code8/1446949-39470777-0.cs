    var myMockedResult = //... whatever
    var securityServiceMock = new Mock<ISecurityService>(MockBehavior.Strict);
    securityServiceMock
        .Setup(s => s.GenerateHashedAndSaltedPassword(It.IsAny<string>(), It.IsAny<byte[]>))
        .Returns(myMockedResult);
