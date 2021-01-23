    [ClassInitialize]
    public void ClassInit(TestContext context)
    {
        TestFoo = new Foo(dynamicDataFromContext);
        Assert.IsNotNull(TestFoo);
    }
