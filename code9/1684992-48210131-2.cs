    [TestClass]
    public class UserControllerShould {
        [TestMethod]
        public async Task GetGroupMembersCollectionWithReferencePage_Success() {
            //Arrange
            var groupId = "12345";
            var expectedResult = Mock.Of<IGroupMembersCollectionWithReferencesPage>();
            var mockService = new Mock<IUserServices>();
            mockService
                .Setup(_ => _.GetGroupMembers(groupId))
                .ReturnsAsync(expectedResult);
            var controller = new UserController(mockService.Object);
            //Act
            var result = await controller.GetGroupMembers(groupId) as System.Web.Http.Results.OkNegotiatedContentResult<IGroupMembersCollectionWithReferencesPage>;
            //Assert
            Assert.IsNotNull(result);
            var actualResult = result.Content;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
