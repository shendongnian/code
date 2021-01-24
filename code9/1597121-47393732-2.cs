    public static class DriverUtils
    {	
        private static IWebDriver driver;
        private static TestContext testContext;
        private static string testEnvironment = string.Empty;
        // [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            testContext = context;
            testEnvironment = Convert.ToString(testContext.Properties["TestEnvironmentUrl"]);
        }
	}	
    
