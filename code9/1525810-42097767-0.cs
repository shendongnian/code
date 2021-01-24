    namespace Automation_Suite
    {
        public partial class redSuite : Form
        {
            private IWebDriver driver = new ChromeDriver(); //define driver here so you can use it in methods.
    
            public redSuite()
            {
                InitializeComponent();
            }
    
            public void logInAutomation()
            {
    
                driver.Url = "DESTINATION URL";
    
                //Finds Username field and enters username
                IWebElement element = driver.FindElement(By.Name("USERNAME LOG IN"));
                element.SendKeys("USERNAME");
    
                //Finds Password field and enters password
                element = driver.FindElement(By.Name("PASSWORD AUTOMATION"));
                element.SendKeys("PASSWORD");
    
                //Clicks Submit
                driver.FindElement(By.Id("SUBMIT BUTTON")).Click();
            }
    
            public void button1_Click(object sender, EventArgs e)
            {
                this.Close();
            }
    
            private void hostedGalleryBtn_Click(object sender, EventArgs e)
            {
                logInAutomation();
    
                IWebElement element = element = driver.FindElement(By.Name("COMPANY ID"));
                element.SendKeys("ID NUMBER");
            }
        } 
    }
