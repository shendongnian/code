    public void Test()
    {
        // Arrange
        var child = new Mock<IChild>();
        var main = CreateMain(child: child.Object);
        // Act
        main.DoSomething();
        // Assert
        Assert.IsTrue(child.ExpectSomethingOnChild);
    }
