    public class LandingPageTests
    {
        IApp app;
        Platform platform;
        LandingPage _landingPage;
    
        public Tests(Platform platform)
        {
            this.platform = platform;
        }
    
        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
            _landingPage =  = new LandingPage(app);
        }
    
        [Test]
        public void AttemptInvalidLogin()
        {
            _landingPage.Login(app, "test123", "test123");
        }
    }
