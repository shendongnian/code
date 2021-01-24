    [TearDown]
	    public void TearDown()
	    {
		    if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
		    {
			    var screenshot = ((ITakesScreenshot)browser).GetScreenshot();
			    var filename = TestContext.CurrentContext.Test.MethodName + "_screenshot_" + DateTime.Now.Ticks + ".jpg";
			    var path = "C:\\Temp\\" + filename;
			    screenshot.SaveAsFile(path , ScreenshotImageFormat.Jpeg);
			    TestContext.AddTestAttachment(path);
		    }
		    browser.Quit();
	    }
