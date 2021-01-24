    [Theory]
    [MemberData(nameof(ConfigTestCase.TestCases), MemberType = typeof(ConfigTestCase))]
    public void Test(Func<Config, object> func)
    {
        var config = serviceProvider.GetService<GenericConfig>();
        var result = func(config.Config1);
    
        Assert.True(!string.IsNullOrEmpty(result));
    }
