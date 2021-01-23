    [TestMethod]
    public void Moq_SetupSequence_Example() {
        //Arrange
        var mock = new Mock<IOutputManager>();
        mock.SetupSequence(x => x.WriteMessage(It.IsAny<string>()))
            .Returns("first")
            .Returns("second")
            .Throws<InvalidOperationException>();
        var outputManager = mock.Object;
        var sut = new DependentOnIOutputManager(outputManager);
        //Act
        var first = sut.SomeMethod("1st");
        var second = sut.SomeMethod("2nd");
        Exception e = null;
        try {
            sut.SomeMethod("3rd");
        } catch (InvalidOperationException ex) {
            e = ex;
        }
        //Assert
        Assert.IsNotNull(first);
        Assert.IsNotNull(second);
        Assert.IsNotNull(e);
    }
