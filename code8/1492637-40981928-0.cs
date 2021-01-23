    [Test]
    public void Returns_Yes_When_True() {
        //Arrange
        var expected = "yes";
        var sut = new TestController();
        //Act
        var actual = sut.MethodToTest()
        //Assert
        Assert.That(expected == actual);
    }
