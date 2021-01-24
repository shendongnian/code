    public class HeaderPageObject
    {
        [FindsBy(How = How.Name, Using = "username")]
        private IWebElement UsernameField;
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement PasswordField;
        public void Login() 
        {
            // Login to the application
        }
    }
    public class FooterPageObject
    {
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement MailingListFormEmail;
        public void SubscribeToMailingList() 
        {
            // Subscribe to the mailinglist
        }
    }
    public class IndexPage : HeaderPageObject, FooterPageObject
    {
        // Your Concrete page here
    }
