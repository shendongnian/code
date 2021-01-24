    [TestMethod]
    public void GivenPerson_WhenSearchingForFutureBirthDate_ThenValidationMessageShouldBeShown() {
        //Arrange
        var model = new PersonModel() {
            Name = string.Empty,
            SelectionSubmitted = true
        };
        var serviceMock = new Mock<IPersonModelService>();
        serviceMock.Setup(_ => _.Get(It.IsAny<PersonModel>())).Returns(string.Empty);
        var controller = new HomeController(serviceMock.Object);
        //Act
        controller.Index(model);
        //Assert
        var isShowSummarySetToTrue = model.ShowValidationSummary;
        Assert.IsTrue(isShowSummarySetToTrue);
    }
