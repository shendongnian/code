    [TestClass()]
    public class Init
    {
        [AssemblyInitialize()]
        public static void initialize(TestContext testContext)
        {
                ContextProvider.setContext(new APITestContext());
        }
    }
