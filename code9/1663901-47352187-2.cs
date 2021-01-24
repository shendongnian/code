    [Fact]
    public async Task RegisterNewUser_ReturnsHttpStatusBadRequest_WhenViewModelPosted() {
        //Arrange
    
        //...code removed for brevity
    
        mockUserManager
            .Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "test"}));
    
        //...code removed for brevity
    
        //Assert
        actual
            .Should().NotBeNull()
            .And.Match<HttpResponseMessage>(_ => _.StatusCode == HttpStatusCode.BadRequest);
    }
