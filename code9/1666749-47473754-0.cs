    class CrearAlumnoPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public CrearAlumnoPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            // WebDriverWait is in OpenQA.Selenium.Support.UI
        }
        public IWebElement GetIFrame(string id)
        {
            return wait.Until(ExpectedConditions.ElementLocated(By.Id(id)));
        }
    }
