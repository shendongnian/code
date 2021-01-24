    IWebDriver driverIE = new InternetExplorerDriver();
    driverIE.Manage().Window.Maximize();
    driverIE.Navigate().GoToUrl(@"https://DemoOriginalWebsite.Com");
    AutoItX.ControlFocus("Windows Security", "", "Edit1");
    AutoItX.ControlSetText("Windows Security", "", "Edit1","userid");
    AutoItX.ControlFocus("Windows Security", "", "Edit2");
    AutoItX.ControlSetText("Windows Security", "", "Edit2", "password");
    AutoItX.ControlClick("Windows Security", "", "Button2");
    //Do your work.
    driverIE.Dispose();
