	[TestMethod]
	public void UnitTest1()
	{
		//	Put your Test assembly name here
		Configuration configuration = ConfigurationManager.OpenExeConfiguration(@"SimpleTestsUnits.dll");
		Assert.AreEqual("20", configuration.AppSettings.Settings["TestKey"].Value);
	}
