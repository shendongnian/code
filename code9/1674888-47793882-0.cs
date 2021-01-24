    public class NavigationBar
    {
        [FindsBy(How = How.LinkText, Using = "Next")]
        private IWebElement Next;
    
    	[FindsBy(How = How.LinkText, Using = "Previous")]
        private IWebElement Previous;
    
        public NavigationBar(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this)
        }
    }
    public class DashboardPage
    {
        public NavigationBar NavigationBar { get; set; }
    
        public DashboardPage(IWebDriver driver)
        {
            NavigationBar = new NavigationBar(driver);
        }
    }
    public class ClientDetailsOnePage
    {
        public NavigationBar NavigationBar { get; set; }
    
        public ClientDetailsOnePage(IWebDriver driver)
        {
            NavigationBar = new NavigationBar(driver);
        }
    }
