    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            // Arrange
            Employee user = new Employee()
            {
                EmployeeId = 1,
                FirstName = "Mike"
            };
            var simulatingLoggedUser = new Mock<ISessionManager>();
            simulatingLoggedUser.Setup(x => x.CurrentUser).Returns(user);
            simulatingLoggedUser.Setup(x => x.UserType).Returns("ADMIN");
            simulatingLoggedUser.Setup(x => x.IsUserLoggedIn).Returns(true);
            HomeController homeController = new HomeController(simulatingLoggedUser.Object);
            // Act
            var result = homeController.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
    }
