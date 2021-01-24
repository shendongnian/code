    [Fact]
    public async Task RegisterNewUser_ReturnsHttpStatusBadRequest_WhenInvalidModelState() {
        //Arrange
        var mockStore = Mock.Of<IUserStore<ApplicationUser>>();
        var mockUserManager = new Mock<UserManager<ApplicationUser>>(mockStore, null, null, null, null, null, null, null, null);
 
        var sut = new MembershipController(mockUserManager.Object);
        sut.ModelState.AddModelError("", "invalid data");
        var input = new NewUserInputBuilder().Build();
        //Act
        var actual = await sut.RegisterNewUser(input);
        //Assert
        actual
            .Should().NotBeNull()
            .And.Match<HttpResponseMessage>(_ => _.StatusCode == HttpStatusCode.BadRequest);    
    }
