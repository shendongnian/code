    [TestInitialize]
    public void TestInitialize() {
        _userId = "1";
        var data = new List<Contact>();//To store test data.
        //Configure repository
        var fakeRepository = new FakeContactRepository(data);
        //Configure UoW
        _mockUoW = new Mock<IUnitOfWork>();
        _mockUoW.SetupGet(u => u.Contacts).Returns(fakeRepository );
        _controller = new ContactsController(_mockUoW.Object);
        _controller.MockCurrentUser(_userId, "user@domain.com");
    }
