    [Fact]
    public void CustomizeSpecificProperty()
    {
        var fixture = new Fixture();
        fixture.Customize<MyClass>(c => c.With(mo => mo.Number, 42));
        var actual = fixture.Create<MyClass>();
        Assert.Equal(42, actual.Number);
    }
