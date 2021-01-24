    loginInput.SendKeys("test"); // the beginning of my email adress
    var actions = new OpenQA.Selenium.Interactions.Actions(driver);
    actions.KeyDown(Keys.Control).KeyDown(Keys.LeftAlt); // I press my graph key "ALT GR"
    actions.SendKeys("à"); // Then, my key "@"
    actions.KeyUp(Keys.Control).KeyUp(Keys.LeftAlt); // I release my key
    actions.Build().Perform(); // execute
    loginInput.SendKeys("test.fr"); // the end of my email adress
