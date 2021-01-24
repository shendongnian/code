    [Given(@"Everything is installed")]
    public void GivenEverythingIsInstalled()
    {
      // Perform Installation with no assertion
      // You can use this step just to do the setup
      // No assertions literally just perform all the actions required to install 
    }
    [Then(@"its all installed correctly")]
    public void ThenItsAllInstalledCorrectly()
    {
      // Because you have inherited the TechTalk.SpecFlow.Steps class
      Given("Everything is installed");
      Assert.IsTrue(CorrectInstallCheckMehtod(), "It should have installed");
    }
