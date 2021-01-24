    [Theory]
    [InlineData(1)]
    public async void IdeaManager_Should_Return_ViewResult(int _currentTenanatID) {
        // Arrange ..
        var ideaManagementService = new Mock<IIdeaManagementService>();
        var tenantService = new Mock<ITenantService>();
        var authorizationService = new Mock<IAuthorizationService>();
        var sut = new IdeaManagementController(
                         ideaManagementService.Object,
                         tenantService.Object,
                         null,
                         authorizationService.Object,
                         null);
         authorizationService
             .Setup(_ => _.AuthorizeAsync(It.IsAny<IPrincipal>(), "IdeaManagement_Coordinator"))
             .ReturnsAsync(true);
         tenantService
             .Setup(_ => _.GetCurrentTenantId())
             .Returns(_currentTenanatID);
         var ideas = new //{what ever is your expected return type here}
         ideaManagementService
             .Setup(_ => _.GetByIdeaCoordinator(_currentTenanatID))
             .Returns(ideas);
        // Act 
        var _view = await sut.IdeaCoordinator() as ViewResult;
    
        // Assert
        Assert.IsNotNull(_view);
        Assert.IsType(typeof(ViewResult), _view);
        Assert.AreEqual(ideas, view.Model);
    }
