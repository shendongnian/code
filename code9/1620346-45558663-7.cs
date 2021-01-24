    // ARRANGE
    var dataSource = new List<User>(); //<-- this will hold data
    var user = new User()
    {
        FirstName = "Some",
        LastName = "Guy",
        EmailAddress = "some.guy@mockymoqmoq.com",
    };
    var mockSet = new MockDbSet<User>(dataSource);
    var mockContext = new Mock<WebAPIDbContext>();
    mockContext.Setup(c => c.Set<User>()).Returns(mockSet.Object);
    // ACT
    using (var uow = UnitOfWork.Create(mockContext.Object))
    {
        uow.UserRepository.Add(user);
        uow.SaveChanges();
    
        // ASSERT
        mockSet.Verify(u => u.Add(It.IsAny<User>()), Times.Once());
        Assert.IsTrue(dataSource.Contains(user)); //<-- shows mock actually added item
        Assert.IsTrue(uow.UserRepository.Any(u => u == user)); //<-- show you can actually query mock DbSet
    }
