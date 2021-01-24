    public void GetFormItemsByFormNumber() {
        using (var mock = AutoMock.GetLoose()) {
            // Arrange.
            var serviceMock = mock.Mock<IWebScrapSprocService>();
            serviceMock.Setup(x => x.GetFormItemsByFormNumber(3392)).Verifiable();
            var sut = mock.Create<InScrapController>();
            // Act.   
            var response = sut.GetFormItemsByFormNumber(3392) as OkNegotiatedContentResult<TWhatEverTypeService>();
            // Assert.
            serviceMock.Verify();
            Assert.IsNotNull(response);
        }
    }
