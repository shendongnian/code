    [TestFixture]
    class Tests
    {
            [Test]
            public void Test1
            {
                using(var testInst = new TestCase())
                {
                testInst
                   .Init()
                   .NavigateToHomePage();
                }
            }
    }
    
    public class TestBase:IDisposable
    {
            private IWebDriver BaseWebDriver;
            private TestContext _testContext;
            public NavigatePage Init()
            {
                _testContext = TestContext.CurrentTestContext;
                BaseWebDriver = new ChromeDriver();
                .
                .
                .
            }
    
            public override void Dispose()
            {
                //Kill Driver here
                //TestContext instance will have the AssertCounts
                //But The Testcontext instance will have the result as Inconclusive.
            }
    }
