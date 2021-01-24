    [Fact]
    public void CreateTwoFooObjectsWithDistinctIdentifiers()
    {
        var fixture = new Fixture();
        fixture.Customizations.Add(new UniqueIdentifierBuilder());
        var f1 = fixture.Create<Foo>();
        var f2 = fixture.Create<Foo>();
        Assert.NotEqual(f1.Identifier, f2.Identifier);
    }
    [Fact]
    public void CreateManyFooObjectsWithDistinctIdentifiers()
    {
        var fixture = new Fixture();
        fixture.Customizations.Add(new UniqueIdentifierBuilder());
        var foos = fixture.CreateMany<Foo>();
        Assert.Equal(
            foos.Select(f => f.Identifier).Distinct(),
            foos.Select(f => f.Identifier));
    }
    [Fact]
    public void CreateListOfFooObjectsWithDistinctIdentifiers()
    {
        var fixture = new Fixture();
        fixture.Customizations.Add(new UniqueIdentifierBuilder());
        var foos = fixture.Create<IEnumerable<Foo>>();
        Assert.Equal(
            foos.Select(f => f.Identifier).Distinct(),
            foos.Select(f => f.Identifier));
    }
