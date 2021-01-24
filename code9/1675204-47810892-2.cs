           class Program
             {
              static void Main(string[] args)
                  {
            IWebDriver driver = new ChromeDriver();
                       driver.Navigate().GoToUrl("https://www.tutorialspoint.com/selenium/selenium_automation_practice.htm");
           List<IWebElement> gender_radio = driver.FindElements(By.Name("sex")).ToList();
            int flag = 0;
            if(flag==0)
            {
                gender_radio[0].Click();
            }
             else
            {
                gender_radio[1].Click();
            }
        }
    }
