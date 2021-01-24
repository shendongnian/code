	[TestFixture]
	public class Tests
	{
		iOSApp app;
		[SetUp]
		public void BeforeEachTest()
		{
			app = ConfigureApp.iOS.StartApp();
		}
		[Test]
		public void ViewIsDisplayed()
		{
			AppResult[] results = null;
			if (app.Device.IsPhone)
			{
				results = app.WaitForElement(c => c.Child("UIView"));
			}
			if (app.Device.IsTablet)
			{
				results = app.WaitForElement(c => c.Child("UIView"));
			}
			app.Screenshot("First screen.");
			Assert.IsTrue(results.Any());
		}
	}
