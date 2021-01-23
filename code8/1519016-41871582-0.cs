    [SetUpFixture]
    public class IntegrationTestsBase
    {
        public static IKernel Kernel;
    
        [SetUp]
        public void RunBeforeAnyTests()
        {
            Kernel = new StandardKernel();
            if (Kernel == null)
                throw new Exception("Ninject failure on test base startup!");
    
            Kernel.Load(new ConfigModule());
            Kernel.Load(new RepositoryModule());
        }
    
        [TearDown]
        public void RunAfterAnyTests()
        {
            Kernel.Dispose();
        }
    }
