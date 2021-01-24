    [Fact]
    public void DemoOfFactory()
    {
        var state = Geo.Fakes.State.Create();
        Assert.IsType<Geo.Fakes.State>(state);
        Assert.NotEqual(default(string), state.TheText);
        Assert.NotEqual(default(int), state.TheNumber);
    }
