    [TestMethod]
    public void ConversionController_Get_Should_Return_Five() {
        //Arrange
        var number = 5;
        var expected = "five";
        var mock = new Mock<INumberService>();
        mock.Setup(_ => _.ConvertToWords(number)).Returns(expected);
        var sut = new ConversionController(mock.Object);
        //Act
        var actual = sut.Get(number);
        //Assert
        Assert.AreEqual(expected, actual);
    }
