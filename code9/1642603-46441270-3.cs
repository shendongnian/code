    [Theory, MyServiceAutoData]
    public void CustomizedAutoDataBasedTest(IService s)
    {
        Assert.IsAssignableFrom<MyService>(s);
    }
