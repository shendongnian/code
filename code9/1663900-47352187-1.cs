    [Fact]
    public async Task RegisterNewUser_ReturnsHttpStatusOK_WhenValidModelPosted() {
        //Arrange
        var mockStore = Mock.Of<IUserStore<ApplicationUser>>();
        var mockUserManager = new Mock<UserManager<ApplicationUser>>(mockStore, null, null, null, null, null, null, null, null);
        mockUserManager
            .Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Success);
        var sut = new MembershipController(mockUserManager.Object);
        var input = new NewUserInputBuilder().Build();
        //Act
        var actual = await sut.RegisterNewUser(input);
        //Assert
        actual
            .Should().NotBeNull()
            .And.Match<HttpResponseMessage>(_ => _.IsSuccessStatusCode == true);        
    }
