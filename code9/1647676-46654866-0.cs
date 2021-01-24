    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    namespace configure
    {
        public partial class Form1 : Form
        {
            IWebDriver driver;
            public Form1()
            {
                InitializeComponent();
      			driver = new ChromeDriver();
     		}
		
		    private void button1_Click(object sender, EventArgs e)
            {
                driver.SwitchTo().Window(driver.WindowHandles.First());
                driver.Navigate().GoToUrl("http://www.yourURL.com.br");
            }
    	}
    }
