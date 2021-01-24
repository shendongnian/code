    [TestMethod]
    public void Foo_DoesBar_WhenBaz()
    {
        var options = new DbContextOptionsBuilder<BloggingContext>()
            .UseInMemoryDatabase(databaseName: "foo_bar_baz")
            .Options;
        using (var context = new BloggingContext(options))
        {
            ...
        }
    }
