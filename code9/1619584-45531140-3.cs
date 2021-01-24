    [Fact]
    public async Task CreateUser_True() {
        //arrange
        var usersRepository = new Mock<IRepository<User, int>>();
        var userResolverService = new Mock<IUserResolverService>();
        var tokenService = new Mock<ITokenService>();
        var user = new User() {
            Email = "test@test.com",
            CustomerId = 1
        };
        var users = new List<User>() { user };
        
        usersRepository.Setup(_ => _.GetAllAsync()).ReturnsAsync(users);
        usersRepository.Setup(_ => _.AddAsync(It.IsAny<User>()))
            .Returns<User>(arg => Task.FromResult(arg)) //<-- returning the input value from task.
            .Callback<User>(arg => users.Add(arg)); //<-- use call back to perform function
        userResolverService.Setup(_ => _.GetCustomerId()).Returns(2);
        var accountService = new AccountService(usersRepository.Object, userResolverService.Object, tokenService.Object);
        //act
        var actual = await accountService.CreateUser(new UserDto { 
            Email = "email@example.com",
            Password = "monkey123",
            //...other code removed for brevity
        });
        //assert
        Assert.IsTrue(actual);
        Assert.IsTrue(users.Count == 2);
        Assert.IsTrue(users.Any(u => u.CustomerId == 2);
    }
