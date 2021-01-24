    namespace VistaBest.XUnitTest.Api.Test
    {
      public class Account_UnitTest
      {
        private readonly Mock<IUsersBusinessObject> _usersBusinessObjectMock;
        private readonly AccountController _accountController;
        public Account_UnitTest() 
        {
           _usersBusinessObjectMock = new Mock<IUsersBusinessObject>();
           _accountController = new AccountController(_usersBusinessObjectMock.Object);
        }
        [Fact]
        public void ValidateUserTest()
        {
            _usersBusinessObjectMock.Setup(service => service.ValidateUser(username, password)).Returns(() => true);
            var actual = _accountController.ValidateUser(new LoginModel
            {
                Username = "admin",
                Password = "admin"
            }) as OkObjectResult;
            actual.Value.ShouldBeEquivalentTo(True); 
            // or Assert.True(actual.Value);
        }
      }
    }
