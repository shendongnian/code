    [TestMethod]
    public void Save_WhenCalled_ExecutesSave() {
        //Arrange
        var num = 3;
        var mock = new Mock<IPrimeDb>();
        var sut = new PrimeChecker(mock.Object);
        mock.Setup(_ => _.Save(num)).Returns(sut.IsPrime(num));
        //Act
        var actual = sut.Save(num);
        //Assert
        Assert.IsTrue(actual);
        mock.Verify(_ => _.Save(num), Times.AtMostOnce());
    }
