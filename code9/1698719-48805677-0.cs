			namespace AutomationStuffs.SmokeTests
			{
				[TestFixture]
				public class canvas : TestBase
				{
					[Test]
					[TestCaseSource(typeof(TestBase), "TestData")]
					public void canvasBob(String BrowserName, String Environment, String System)
					{
						//Configure test setup - within my environment i would usually perform a repeated login step here within setup
						Setup(BrowserName, Environment, System, new string[] { });
						//GoTo Google
						KnowledgeBasePage.GoToGoogle();
						GooglePage.ClickImFeelingLucky();
						Assert.IsTrue(googlePage.OnTheImFeelingLuckyPage());
					}
				}
			}
---------------
        public static void ClickImFeelingLucky()
        {
            Wait.WaitForPageElementToBeVisible(By.Name("q"), 10);
            string MyPicture = @"C:\..\intractionImages\Capture.PNG";
            Console.WriteLine(MyPicture);
            SikuliAction.Click(MyPicture);
            Wait.WaitForPageElementToBeVisible(By.Id("lang-chooser"), 10);
        }
