    [TestMethod]
    public void TwoNumbersDescendingAreSwapped()
    {
        // Arrange
        var input = "2 1";
        var expectedOutput = "1 2"; 
        // Act
        var actualOutput = InputConverter.MyMethod(input);
        // Assert
        Assert.AreEqual(expectedOutput, actualOutput);
    }
