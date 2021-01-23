    [Test]
    public async Task Test1([Values(200)]int personId) {
        //Arrange
        double expectedResult = 20.0;
        var serviceMock = new Mock<IAccountService>();
    
        serviceMock
            .Setup(x => x.GetAccDetails(It.Is<int>(id => id == personId)))
            .ReturnsAsync(expectedResult); // User ReturnsAsync here
    
        var person = new Person(personId, serviceMock.Object);
    
        //Act
        await person.UpdateBanckingAcc();
        var actualResult = person.Amount;
    
        //Assert
        Assert.AreEqual(expectedResult, actualResult);
    }
