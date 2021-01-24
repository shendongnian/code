    [TestClass]
    public abstract class TestBase
    {
        [AssemblyInitialize]
        public static void ContextInitialize(TestContext context)
        {
            DriverUtils.Initialize(context);
        }
	}
