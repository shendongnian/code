    [Fact]
    public void Example()
    {
        var fixture = new Fixture();
        fixture.Customizations.Add(
            new ElementsBuilder<MyObject>(
                new MyObject("foo"),
                new MyObject("bar"),
                new MyObject("baz")));
        var actual = fixture.Create<MyObject>();
            
        Assert.Contains(actual.Name, new[] { "foo", "bar", "baz" });
    }
