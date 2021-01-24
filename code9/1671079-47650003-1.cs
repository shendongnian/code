    [TestMethod]
    public void Given_Blah_MyConcreteMethod_ShouldReturnTrue() {
        // Arrange
        var myMock = Substitute.For<IMyInterface>();
        var arg = "blah";
        var expected = true;
        myMock.MyMethod(arg).Returns(expected);
        var myTestedObject = new MyTestedClass(myMock);
        // Act
        var actual = myTestedObject.MyConcreteMethod(arg);
        // Assert
        Assert.AreEqual(expected, actual); // This should pass
    }
