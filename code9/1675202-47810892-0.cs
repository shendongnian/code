           class Program
             {
              static void Main(string[] args)
                  {
            IWebDriver driver = new ChromeDriver();
                       driver.Navigate().GoToUrl("https://www.tutorialspoint.com/selenium/selenium_automation_pr                    actice.htm");
           List<IWebElement> gender_radio = driver.FindElements(By.Name("sex")).ToList();
            bool value;
            int flag = 0;
            value = gender_radio[0].Selected;
            if (value)
            {
                Console.WriteLine("You have chosen male");
                flag = 1;
            }
            value = gender_radio[1].Selected;
            if (value)
            {
                Console.WriteLine("You have chosen Female");
                flag = 1;
            }
            if(flag==0)
            {
                gender_radio[0].Click();
            }
        }
    }
