    [Theory]
    [MemberData(nameof(ConfigTestCase.TestCases), MemberType = typeof(ConfigTestCase))]
    public void Test(string currentField)
    {
        var func = ConfigTestCase.testCases.FirstOrDefault(x => x.Key == currentField).Value;
        var config = serviceProvider.GetService<GenericConfig>();
        var result = func(config.Config1);
            
        Assert.True(!string.IsNullOrEmpty(result));
    }
