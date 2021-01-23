    [TestMethod]
    public void UpdateBackingAcc_WhenCalled_AmountContainsValueReturnedFromService()
    {
        Mock<IService> serviceMock = new Mock<IService>();
        const double expectedResult = 100;
        const int personId = 200;
        serviceMock.Setup(s => s.GetAccDetails(It.Is<int>(id => id == personId)))
            .Returns(() => expectedResult);
        Person person = new Person(personId, serviceMock.Object);
        // Act
        person.UpdateBackingAcc();
        // Assert
        double actualResult = person.Amount;
        Assert.AreEqual(expectedResult, actualResult);
    }
