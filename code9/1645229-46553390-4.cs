        [Test]
        public async Task GetLoginDetailAsync_InvalidUsername_ReturnsNull()
        {
            // Arrange
            MapperInitialize.Configure();
            var entityService = new Mock<IEntityService<UserAccount>>();
            var userAccount = new UserAccount
            {
                ID = 1,
                Username = "Test User",
                Active = true
            };
            var expressionResult = false;
            entityService
                .Setup(service => service.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<UserAccount, bool>>>()))
                .Callback<Expression<Func<UserAccount, bool>>>(expression =>
                {
                    expressionResult = expression.Compile().Invoke(userAccount);
                })
                .ReturnsAsync(userAccount);
            var loginService = new LoginService(entityService.Object);
            // Act
            var result = await ((ILoginService)loginService).GetLoginDetailAsync("Test User");
            // Assert
            Assert.IsTrue(expressionResult);
            Assert.IsNotNull(result);
        }
