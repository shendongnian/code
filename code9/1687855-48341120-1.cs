    //Arrange
    var logger = new Mock<ILog>();
    logger
        .Setup(_ => _.Create(It.IsAny<AuditAction>(), It.IsAny<long>(), It.IsAny<string>()))
        .Return(new AuditTrail);
    
    var controller = new BaseController(logger.Object, null);
    
    //Act
    
    //...
