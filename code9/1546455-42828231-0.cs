    [TestInitialize]
    public void Initialize()
    {
        bool skipInitialize = GetType().GetMethod(TestContext.TestName)
            .GetCustomAttributes<SkipInitializeAttribute>().Any();
        if (!skipInitialize)
        {
            // Initialization code here
        }
    }
