    public static bool IsInValidLocation(string invalidLocation)
        {
            By selector = By.XPath("/html/body/header/div/div[4]/div/div/div[2]/div[1]/form/div[2]/span[2]");
            // You might want to research how to construct stable xpaths/selctors
            new WebDriverWait(driver.Instance, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(selector));
            var ErrorMessage = driver.Instance.FindElement(selector);
            bool result = ErrorMessage.Text.Contains(InvalidLocation); 
            return result;
        }
