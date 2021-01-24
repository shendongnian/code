    Dictionary<string, int> dictionaryFromExcel = new Dictionary<string, int>
            {
                {"High", 400},
                {"Medium", 100},
                {"Low", 50}
            };
    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(dictionaryFromExcel["Medium"]);
