    [Test]
    public async Task GetLoginDetailAsync_InvalidUsername_ReturnsNull()
    {
        // Arrange
        MapperInitialize.Configure();
        var entityService = new Mock<IEntityService<UserAccount>>();
            
        entityService
            .Setup(service => service.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<UserAccount, bool>>>()))
            .ReturnsAsync(new UserAccount
            {
                ID = 1,
                Name = "Test User"
            });
        var loginService = new LoginService(entityService.Object);
            
        // Act
        var result = await ((ILoginService)loginService).GetLoginDetailAsync(It.IsAny<string>());
        // Assert
        Assert.IsNotNull(result);
    }
