    public class MyPageObject
        {
            private readonly IWebDriver _driver;
    
            [FindsBy(How = How.Id, Using = "id")]
            private IWebElement _myWebElementInIFrame;
    
            public MyPageObject(IWebDriver webDriver)
            {
                PageFactory.InitElements(webDriver, this);
                _driver = webDriver;
            }
    
            public void DoStuff()
            {
                SwitchToIframe("myiframe");
                _myWebElementInIFrame.Click(); //element found using PageFactory data now
                SwitchToDefaultContent();
            }
    
            public void SwitchToIframe(string frameName)
            {
                _driver.SwitchTo().Frame(frameName);
            }
    
            public void SwitchToDefaultContent()
            {
                _driver.SwitchTo().DefaultContent();
            }
        }
