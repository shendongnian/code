	[TestFixture]
	public class SBase
	{
	protected IWebDriver driver;
		[SetUp]
		public void SetUp()
		{
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://abcd.com");
		}
		[TearDown]
		public void TearDown()
		{
		    if (driver != null)
				driver.Quit();
        }
		[Test]
		public void Test1()
		{
		}
		[Test]
		public void Test2()
		{
		}
	}
