    [SetUpFixture]
    public class ConfigKludge
    {
        [OneTimeSetUp]
        public void Setup() =>
            File.Copy(
                Assembly.GetExecutingAssembly().Location + ".config",
                Assembly.GetEntryAssembly().Location + ".config",
                true);
        [OneTimeTearDown]
        public void Teardown() =>
            File.Delete(Assembly.GetEntryAssembly().Location + ".config");
    }
