    [TestMethod]
    public void When_4_Pounds() {
        //Arrange
        var totalWeight = 4;
        var expected = 3.5M;
        //Act
        var actual = CalculateRate(totalWeight, rates);
        //Assert
        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void When_Ten_Pounds() {
        //Arrange
        var totalWeight = 10;
        var expected = 10M;
        //Act
        var actual = CalculateRate(totalWeight, rates);
        //Assert
        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void When_Thirty_Pounds() {
        //Arrange
        var totalWeight = 30;
        var expected = 10.5M;
        //Act
        var actual = CalculateRate(totalWeight, rates);
        //Assert
        Assert.AreEqual(expected, actual);
    }
