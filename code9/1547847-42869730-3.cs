    [TestFixture]
    public class UserControllerTest
    {
        private User _user1;
        private User _user2;
        private IList<User> _users;
    
        [SetUp]
        public void SetUp()
        {
            _user1 = new User { FirstName = "John", LastName = "Doe" };
            _user2 = new User { FirstName = "Janet", LastName = "Doe" };
            _users = new List<User> { _user1, _user2 };
        }
    
        [Test]
        public void GetAllUsers_ReturnUsers()
        {
            // Arrange
            var requests = Substitute.For<IRequests>();
            requests.GetFromUri(Arg.Any<string>()).Returns(JsonConvert.SerializeObject(_users));
    
            var sut = new UsersController(requests);
    
            // Act
            var result = sut.GetAllUsers() as JsonResult;
    
            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            var users = result.Data as UserResponse;
            Assert.AreEqual(users.usersDetails[0].FirstName, _users[0].FirstName);
            Assert.AreEqual(users.usersDetails[1].FirstName, _users[1].FirstName);
        }
    }
