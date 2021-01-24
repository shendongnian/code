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
            var model = new LoginModel
            {
                Username = "admin",
                Password = "admin"
            };
            _usersBusinessObjectMock.Setup(service => service.ValidateUser(model.Username, model.Password)).Returns(() => true);
            var actual = _accountController.ValidateUser(model) as OkObjectResult;
            actual.Value.ShouldBeEquivalentTo(true); 
            // or Assert.True(actual.Value);
        }
      }
    }
