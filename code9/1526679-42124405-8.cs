    [TestMethod]
    public async Task AccountPerission_PermissionScope() {
        //Arrange
    
        //..code removed for brevity
    
        _applicationUserManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(appUser);
    
        //Act    
        var result = await controller.AjaxResetUserPermission(appUser.Id, 1);
    
        //Assert
        Assert.IsNotNull(result);
    }
