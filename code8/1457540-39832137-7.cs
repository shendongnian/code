    [TestClass]
    public class FriendsControllerTests {
        [TestMethod]
        public void GetFacebookFriendsTest() {
            //Arrange
            var facebook = Mock.Of<IFacebookService>();
            var facebookMock = Mock.Get(facebook);
            facebookMock.Setup(m => m.GetFriends()).Returns("{json of friends}");
    
            var sut = new FriendsController(facebook);
    
            //Act
            var actionResult = sut.GetFacebookFriends();
    
            //Assert
            //...do your assertions here 
        }
    }
