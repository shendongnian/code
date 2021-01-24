    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    
    namespace Example
    {
        public class Form
        {
    		public IWebElement Filter => Driver.FindElement(By.Name("Filter"));   
    		/*
            [FindsBy(How = How.Name, Using = "Filter")] // This does exist in current context using .NET Core
            public IWebElement Filter { get; set; }
    		*/
    		
    		public IWebElement Button => Driver.FindElement(By.TagName("Button"));   
    		/*
            [FindsBy(How = How.TagName, Using = "Button")]
            public IWebElement Button;
    		*/
            public Form(IWebDriver driver)
            {
                //PageFactory.InitElements(driver, this); // This doesn't exist in current context using .NET Core
            }
        }
    }
