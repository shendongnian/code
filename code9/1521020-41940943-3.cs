    [TestMethod]
    public void GroupController_NewGroup_Valid() {
        // Arrange
        var _fakegroup = new Mock<IGroupService>();
        _fakegroup.Setup(g => g.NewGroup(It.IsAny<Group>())).Returns(1).Verifiable();
        var controller = new GroupController(_fakegroup.Object);
        var _gp = new Group {
            ID = 0,
            Name = "Group Name",
            IsOperations = false,
            OperationPermission = Permission.Read
        };
        // Act
        var result = controller.NewGroup(_gp) as JsonResult;
        // Assert
        _fakegroup.Verify();
        Assert.IsNotNull(result.Data, "There should be some data for the JsonResult");
        dynamic data = result.Data;
        Assert.IsNotNull(data.status, "JSON record does not contain 'status' required property.");
        Assert.IsTrue(data.status.Equals("success"), "status must be 'success'");
    }
