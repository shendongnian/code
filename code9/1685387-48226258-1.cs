    [Fact]
    public void CustomizeTextPropertyByConvention()
    {
        var fixture = new Fixture();
        fixture.Customizations.Add(new TextPropertyBuilder());
        var actual = fixture.Create<MyClass>();
        Assert.Equal("Foo", actual.Text);
    }
