			//C# Appium getting time
			using OpenQA.Selenium.Appium;
			using OpenQA.Selenium.Appium.Android;
			namespace YourNameSpace
			{
				[TestClass]
				public class UnitTest1
				{
					//Creating instance for Appium driver
					AppiumDriver<AndroidElement> _driver;
					[TestMethod]
					public void MainScreen()
					{
					  //set the capabilities 
					   (https://github.com/appium/appium/blob/master/docs/en/writing-running-appium/caps.md)
						DesiredCapabilities cap = new DesiredCapabilities();
						//remember to put here all your DesiredCapabilities
						_driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);
						String deviceDateX = _driver.DeviceTime; //Geting device date and time.
						Console.WriteLine(deviceDateX); //Writing the date and time in console
						_driver.Quit();
					
					}
				}
			}
