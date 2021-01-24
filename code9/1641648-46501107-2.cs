    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using test_TestAutomation.TestClasses;
    
    namespace test_TestAutomation.PageObjects
    {
        public class LoginPage
        {
            [FindsBy(How = How.Id, Using = "Email")]
            public IWebElement LoginEmailTxtLocator;
    
            [FindsBy(How = How.Id, Using = "Password")]
            public IWebElement LoginPasswordTxtLocator;
    
            [FindsBy(How = How.CssSelector, Using = "#loginForm > div > div > form > div:nth-child(5) > div > input")]
            private IWebElement BtnLogin;
    
            public LoginPage()
            {
                PageFactory.InitElements(Base.driver, this);
            }
    
            public LoginPage LoginSuccess()
            {
                LoginEmailTxtLocator.SendKeys("emailtest@gmail.com");
                LoginPasswordTxtLocator.SendKeys("xxxxxxx");
                BtnLogin.Click();
                return this;
            }
        }
    }
