    namespace MultipleBrowserTest
    {
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(EdgeDriver))]
    public class SiteLoadsTest_InheritedBrowser : Browsers_Reflection
    {
    public SiteLoadsTest_InheritedBrowser(Type type) : base(type)
        {
        }
        [Test]
        public void MultipleBrowserTests()
        {
            Driver.Navigate().GoToUrl("https://google.com/");
            Driver.Url.ShouldContain("google");
        }
    }
    }
