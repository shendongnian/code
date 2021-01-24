    [TestMethod]
    public async Task TestGet() {
        var foo = new Foo();
        var result = await foo.GetWebAsync();
        Assert.IsNotNull(result, "error");
        Console.Write(result);
    }
