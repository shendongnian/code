    public class BasePageObject
    {
        [FindsBy(How = How.Name, Using = "username")]
        private IWebElement UsernameField;
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement PasswordField;
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement MailingListFormEmail;
        public void Login() 
        {
            // Login to the application
        }
        public void SubscribeToMailingList() 
        {
            // Subscribe to the mailinglist
        }
    }
        
    public class IndexPage : BasePageObject
    {
        // Your Concrete page here
    }
