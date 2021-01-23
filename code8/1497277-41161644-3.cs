    [TestClass]
    class HomeControllerTests
    {
        private HomeController _homeController;
        [TestInitialize]
        public void Init()
        {
            // Arrange
            var user = new User(new ClientContext("http://localhost"), 
                new ObjectPathConstructor(new ClientContext("http://localhost"), string.Empty, null));
            user.Title = "TestUser";
            var mockWeb = new Mock<IWeb>();
            mockWeb.SetupGet(w => w.CurrentUser).Returns(user);
            var mockClient = new Mock<IClientContext>();
            mockClient.SetupGet(c => c.Web).Returns(mockWeb.Object);
            _homeController = new HomeController(mockClient.Object);
        }
        [TestMethod]
        public void Index()
        {
            // Act
            var result = (ViewResult)_homeController.Index();
            // Assert
            result.Should().BeViewResult();
            string userName = result.ViewBag.UserName;
            userName.Should().Be("TestUser");
        }
    }
