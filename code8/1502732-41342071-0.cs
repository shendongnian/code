    public class Header 
        {
        [FindsBy(How = How.ClassName, Using = "logout_button")]
        public virtual IWebElement BtnLogout { get; set; }
    
        public Header()
        {
         PageFactory.InitElements(Browser.Driver, this);
        }
    
        public void Logout()
        {
            this.BtnLogout.Click();
    
        }
    
    }
    
    public class SecondHeader: Header
    {
        [FindsBy(How = How.ClassName, Using = "logout")]
        public overidde IWebElement BtnLogout { get; set; }
    }
