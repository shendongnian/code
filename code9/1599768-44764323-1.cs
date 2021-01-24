    [Test]
    public async Task Test() {
        //Arrrange
        var name = "name";
        var email = "user@emial.com";
        var firstname = "first name";
        var lastname = "last name";
        var userRepositoryMock = new Mock<IUserRepository>();
        //Testing that it returns no user for that name so return null from async call
        userRepositoryMock.Setup(_ => _.GetByNameAsync(name)).ReturnsAsync((User)null);
        //Need this to make sure async call runs to completion
        userRepositoryMock.Setup(_ => _.AddAsync(It.IsAny<User>())).Returns(Task.FromResult((object)null));
            
        var activeDirectoryUserMock = new Mock<IActiveDirectoryUserService>();
        //fake account for mock AD call
        var adUser = new AdUserAccount {
            Email = email,
            FirstName = firstname,
            LastName = lastname
        };            
        //Need fake ad account to return from async call
        activeDirectoryUserMock.Setup(_ => _.GetByNameAsync(name)).ReturnsAsync(adUser);
        var mapperMock = new Mock<IMapper>();
        var userService = new UserService(userRepositoryMock.Object, activeDirectoryUserMock.Object, mapperMock.Object);
        //Act
        await userService.RegisterAsync(name, email, firstname, lastname, "password");
        //Assert
        userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
    }
