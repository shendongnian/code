    // SetUp
    var mockSet = NSubstituteHelper.CreateMockDbSet(_users);
    var mockRepository = Substitute.For<IRepository<User>>();
    mockRepository.Entities.Returns(mockSet);
    _userRepository = mockRepository;
    [Test]
    public async Task GetUserByUserName_ValidUserName_Return1User()
    {
        var sut = new UserService(_userRepository);
        var user = await sut.GetUserByUserNameAsync("123456789");
        Assert.AreEqual(_user3, user);
    }
