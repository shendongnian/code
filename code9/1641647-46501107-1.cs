    using test_TestAutomation.PageObjects;
    using NUnit.Framework;
    
    namespace test_TestAutomation.TestClasses
    {
        class LoginTest : Base
        {
            [Test]
            public void OpenURL()
            {
                driver.Navigate().GoToUrl("http://www.example.com");
            }
    
            [Test]
            public void LoginSuccessCheck()
            {
                driver.Navigate().GoToUrl("http://www.example.com");
                LoginPage login = new LoginPage();
                login.LoginSuccess();
            }
        }
    }
