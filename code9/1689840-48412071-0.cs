    [Test]
    public void Test()
    {
        var product = new Product(new Setting { Value1 = "x", Value2 = "y" }, Mock<Dep1>.Instance);
        // Test method on product
    }
