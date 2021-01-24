    [Fact]
    public void UserRepository_Get()
    {
        var users = new List<UserAccount> {
            new UserAccount { Id = "idstring2", Username = "username2" },
           new UserAccount { Id = "idstring3", Username = "username3" },
        }.AsQueryable();
        var mockSet = new Mock<DbSet<UserAccount>>();
        mockSet.As<IQueryable<UserAccount>>().Setup(m => m.Provider).Returns(users.Provider);
        mockSet.As<IQueryable<UserAccount>>().Setup(m => m.Expression).Returns(users.Expression);
        mockSet.As<IQueryable<UserAccount>>().Setup(m => m.ElementType).Returns(users.ElementType);
        mockSet.As<IQueryable<UserAccount>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());
        var mockContext = new Mock<RentalsDBContext>();
        mockContext.Setup(m => m.Set<UserAccount>()).Returns(mockSet.Object);
        var repository = new RentalsRepository<userAccount>(mockContext.Object);
        var service = new UserService(repository);
        var results = service.GetUserByUsername("username2");
        Assert.Equal("username2", results.Username);
    }
