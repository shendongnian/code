    [TestMethod]
    public void GetAllUsers_Should_Call_Service() {
        //Arrange
        var mock = new Mock<IUsersService>();
        var response = new GetAllUsersResponse {
            usersDetails = new List<User>(),
            errorMessage = string.Empty,
        };
        mock.Setup(m => m.GetAllUsers()).Returns(response);
        var controller = new MainController(mock.Object);
        //Act
        var jsonResult = controller.GetAllUsers();
        //Assert
        mock.Verify(m => m.GetAllUsers(), Times.AtLeastOnce());
    }
