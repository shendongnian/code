    public class ClassName: InheritedClass
    {
        #region Page Objects
        private IWebElement object1;
        private IWebElement object2;
        #endregion
        public ClassName(IWebDriver driver, Size winSize)
        {
            PageFactory.InitElements(driver, this);
            if (winSize.Width > 1440)
            {
                object1= driver.FindElement(expanded By phrase locator);
                object1 = driver.FindElement(expanded By phrase locator);
            }
            else
            {
                object1= driver.FindElement(contracted By phrase locator);
                object1 = driver.FindElement(contracted By phrase locator);
            }
        }
        
        #region Page Methods that use these objects
        #endregion
    }
        
