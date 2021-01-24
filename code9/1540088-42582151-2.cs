    public async Task _GetExchange_GetView_OkModelIsViewModel() {
        //Arrange
        var fakeData = new List<SomeType>() { new SomeType() }; 
        //fake UoF returns fake Data from DB
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork
            .Setup(x => x.SomeRepository.GetAsync())
            .ReturnsAsync(fakeData);
        //fake factory create fake UoF
        var fakeUnitOfWorkFactory = new Mock<UnitOfWorkFactory>();
        fakeUnitOfWorkFactory.Setup(x => x.Create()).Returns(mockUnitOfWork.Object);
        //Our controller
        var controller = new SomeController(fakeUnitOfWorkFactory.Object);
        //Act
        //Our async method
        var result = await controller.SomeMethod() as PartialViewResult;
        //---Assert--
        result.Should().NotBeNull();
        result.Model.Should().NotBeNull();
        CollectionAssert.AreEquivalent(fakeData, result.Model as ICollection);
    }
