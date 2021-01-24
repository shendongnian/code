    [Fact]
    public void ThingDoerSaysWhatConfigTellsItToSay()
    {
        var configWrapper = new FakeConfigWrapper(thingToSay:"Hello");
        var doer = new MyThingDoer(configWrapper);
        Assert.Equal("Hello", doer.SaySomething());
    }
