    [TestInitialize]
    public void TestInitialize() {
        _userId = "1";
        var data = new List<Contact>();//To store test data.
        //Configure repository
        _mockRepository = new Mock<IContactRepository>();
        _mockRepository.Setup(m => m.Add(It.IsAny<Contact>())).Callback<Contact>(data.Add);
        _mockRepository.Setup(m => m.GetContacts(_userId)).Returns(data);
        //Configure UoW
        _mockUoW = new Mock<IUnitOfWork>();
        _mockUoW.SetupGet(u => u.Contacts).Returns(_mockRepository.Object);
        _controller = new ContactsController(_mockUoW.Object);
        _controller.MockCurrentUser(_userId, "user@domain.com");
    }
