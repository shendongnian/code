    public class MyPageObject : BasePageObject
        {
            private readonly IWebDriver _driver;
    
            [FindsBy(How = How.Id, Using = "id")]
            private IWebElement _myWebElementInIFrame;
    
            public MyPageObject(IWebDriver webDriver)
                : base(webDriver)
            {
                PageFactory.InitElements(webDriver, this);
                _driver = webDriver;
            }
    
            public void DoStuff()
            {
                ExecuteActionInIFrame(() =>
                {
                    _myWebElementInIFrame.Click(); //element found using PageFactory data now
                }, "myiframe", "mynestediframe");
            }
        }
    
        public abstract class BasePageObject
        {
            protected IWebDriver WebDriver { get; }
    
            protected BasePageObject(IWebDriver webDriver)
            {
                WebDriver = webDriver;
            }
    
            public void ExecuteActionInIFrame(Action action, params string[] frameNames)
            {
                foreach (string frameName in frameNames)
                {
                    WebDriver.SwitchTo().Frame(frameName); //switch into multiple nested iframes in passed in order
                }
    
                //perform action now that we're in proper iframe
                action();
    
                //bounce out to root to have a standard starting point for next action
                WebDriver.SwitchTo().DefaultContent();
            }
        }
