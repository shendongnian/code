    [Fact]
    public void TestSmthCool()
    {
        var fixture = new Fixture();
        fixture.Customizations.Add(
            new TypeRelay(
                typeof(IService),
                typeof(MyService)
            )
        );
        var s = fixture.Create<IService>();
        Assert.IsAssignableFrom<MyService>(s);
    }
