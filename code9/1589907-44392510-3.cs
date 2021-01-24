    public void GetFormItemsByFormNumber() {
        using (var mock = AutoMock.GetLoose()) {
            // Arrange.
            var serviceMock = mock.Mock<IWebScrapSprocService>();
            serviceMock.Setup(x => x.GetFormItemsByFormNumber(3392))
                .Returns("<Put return value here>") //What should calling the above return
                .Verifiable();  //Tell the mock you want to verify this later
            var sut = mock.Create<InScrapController>();
            // Act.   
            var response = sut.GetFormItemsByFormNumber(3392) as OkNegotiatedContentResult<TWhatEverTypeService>();
            // Assert.
            serviceMock.Verify(); //verify setups were exercised as expected.
            Assert.IsNotNull(response);
        }
    }
