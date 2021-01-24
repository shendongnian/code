    private void HasConfiguration(Func<Config, string> item)
    {
        var configuration = serviceProvider.GetService<GenericConfig>();
        var x = item(configuration.Config1); // Config1 is of type Config
        Assert.True(!string.IsNullOrEmpty(x));            
    }
    [Theory]
    public Test1()
    {
        HasConfiguration((Config y) => y.Param1);
    }    
    [Theory]
    public Test2()
    {
        HasConfiguration((Config y) => y.Param2);
    }
