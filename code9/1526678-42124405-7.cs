    var roles = new List<ApplicationRoles> { new ApplicationRole { Id = "1" } };
    var appUserMock = new Mock<ApplicationUser>();
    appUserMock.SetupAllProperties();
    appUserMock.Setup(m => m.Roles).Returns(roles);
    var appUser = appUserMock.Object;    
    appUser.FirstName = "test";
    appUser.LastName = "tester";
    appUser.Id = "02dfeb89-9b80-4884-b694-862adf38f09d";
    
