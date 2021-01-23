    [TestMethod]
    public async Task UpdateDisplayName_Test() {
        //Arrange
        var mySessionAdaptorService = new Mock<ISessionAdaptorService>();
        var controller = new HomeController(userServiceMock.Object, myProfileServiceMock.Object, mySessionAdaptorService.Object);
    
        var displayName = "display";
        var status = false;
        myProfileServiceMock.Setup(m => m.UpdateDisplayName(It.IsAny<string>(), 1)).Returns(false);
        mySessionAdaptorService.Setup(m => m.Id).Returns(1);
    
        //Act
        var result = await controller.UpdateDisplayName(displayName) as JsonResult;
    
        //Assert
        Assert.IsNotNull(result);
        dynamic data = result.Data;
        Assert.IsNotNull(data);
        Assert.AreEqual(displayName, (string)data.displayname);
        Assert.AreEqual(status, (bool)data.status);
    }
