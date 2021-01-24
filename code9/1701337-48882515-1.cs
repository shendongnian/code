	[TestMethod]
	public void GivenPerson_WhenSearchingForFutureBirthDate_ThenValidationMessageShouldBeShown() {
		//Arrange
		var fakePersonModel = new FakePerson() {
			Name = string.Empty,
			SelectionSubmitted = true
		};
		var controller = new HomeController();
		
		//Act
		controller.Index(fakePersonModel);
		//Assert
		var isShowSummarySetToTrue = fakePersonModel.ShowValidationSummary;
		Assert.IsTrue(isShowSummarySetToTrue);
	}
	
