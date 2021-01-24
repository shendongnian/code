    public void _ListUsersGet_ShouldSucceed() {
        var users = new List<ApplicationUser>
        {
            new ApplicationUser { Id = "1", FirstName = "Test", LastName = "User" }
        }.AsQueryable();
        //Only mocking this because we need it to initialize manager.
        var userStore = Mock.Of<IUserStore<ApplicationUser>>();
        var userManager = new Mock<ApplicationUserManager>(userStore);
        userManager.Setup(_ => _.Users).Returns(users);
        var controller = new ManageController(userManager.Object);
        var result = controller.ListUsers() as ViewResult;
        // Assert some stuff
    }
