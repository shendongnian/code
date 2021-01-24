    [Test]
    public void FooOnValueInjectedTest()
    {
        // Arrange
        bool OnValueInjectedWasRasied = false;
        IFoo foo = new Foo();
        foo.OnValueInjected += (s, e) => OnValueInjectedWasRasied = true;
        // Act
        foo.InjectValue(0,0).Wait();
        // Assert
        Assert.AreEqual(true, OnValueInjectedWasRasied);
    }
