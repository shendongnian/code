    public void SomeDemoServiceTest() {
        //Arrange
        var mockProvider = new Mock<IDemoProvider>();
        mockProvider.Setup(p => p.GetStringById(It.IsAny<int?>())).Returns(() => "success");
        var mockService = new Mock<SomeDemoService>(mockProvider.Object) { CallBase = true };
        mockService.Setup(s => s.Validate(It.IsAny<ServiceRequest>())).Returns(true);
        var request = new ServiceRequest();
        //Act
        var result = mockService.Object.Post(request);
        //Assert
        Assert.AreEqual("success", result);
    }
