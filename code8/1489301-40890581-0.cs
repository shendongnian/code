    [ClassInitialize()]
    public static void MyClassInitialize(TestContext testContext)
    {
        config = RunspaceConfiguration.Create();
    }
