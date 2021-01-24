    [Fact]
    public void UserService_GetUserByUsername()
    {
        var userAccount = new UserAccount { Id = "idstring2", Username = "username2", Email = "" };
        var mockRepo = new Mock<IRentalsRepository<UserAccount>>();
        mockRepo.Setup(m => m.Get("idstring2").Returns(userAccount);
        var testClass = new UserService(mockRepo.Object);
        var results = testClass.GetUserByUsername("idstring2");
        Assert.Equal("idstring2", results.Username);
        Assert.AreEqual("???", results.Email);
    }
