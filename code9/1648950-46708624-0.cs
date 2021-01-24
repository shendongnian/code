    [Fact]
    public void HowToCreateAnAutoConfiguredMoq()
    {
        var fixture = new Fixture().Customize(new AutoConfiguredMoqCustomization());
        var c = fixture.Create<ICustomer>();
        Assert.NotEqual(default(string), c.Name);
    }
