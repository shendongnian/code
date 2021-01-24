    [Test]
    public void Test()
    {
        var setting = new Setting { Value1 = "x", Value2 = "y" };
        var dep1 = new Mock<Dep1>();
        // setup Moq conditions on dep1
        var product = new Product(setting, dep1);
        // Execute method on product and assert
    }
