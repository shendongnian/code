    [TestMethod]
    public void UpdateBackingAcc_WhenCalled_AmountContainsValueReturnedFromService()
    {
        // Arrange
        Mock<IService> serviceMock = new Mock<IService>();
        const double expectedResult = 100;
        serviceMock.Setup(s => s.GetAccDetails(It.IsAny<int>())).Returns(() => expectedResult);
        Person person = new Person(1, serviceMock.Object);
        // Act
        person.UpdateBackingAcc();
        // Assert
        double actualResult = person.Amount;
        Assert.AreEqual(expectedResult, actualResult);
    }
