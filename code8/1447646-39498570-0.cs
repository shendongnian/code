    [Test]
    public void CheckIfPasswordIsHashed_Test()
    {
        // Arrange
        // Mock dependency which is the service and setup
        // GenerateHashedAndSaltedPassword so it does what you need  
        var securityServiceMock = new Mock<User>();
        securityServiceMock.Setup(m => m.GenerateHashedAndSaltedPassword(
            It.IsAny<string>(), 
            ItIsAny<Salt>())
        .Returns(Password);
        
        // TestedClass needs a place where the mocked instance can be injected,
        // e.g. in constructor, or public property
        var testedClass = new TestedClass(securityServiceMock.Object);
        
        // Act
        testedClass.CheckUsersPassword(password);
         
        // Assert
        securityServiceMock.Verify(m => m.GenerateHashedAndSaltedPassword(
            It.IsAny<string>(), 
            ItIsAny<Salt>()), 
        Times.Once());
    }
