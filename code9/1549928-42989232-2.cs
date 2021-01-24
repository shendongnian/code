    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;
        
        namespace tabledata
        {
            class Program
            {
                static void Main(string[] args)
                {
                    IWebDriver driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl("https://www.redmine.org//projects//redmine//issues");
                    driver.FindElement(By.XPath(".//*[@class='per-page']/a[2]")).Click();
        
                    int num_of_clicks = Int32.Parse(driver.FindElement(By.XPath(".//*[@id='content']/p[1]/a[3]")).Text);
        
                    for (byte i = 1; i < num_of_clicks; i++)
                    {
                        for (byte j = 0; j < 100; j++)
                        {
                            String Issue_Subject = driver.FindElement(By.XPath(".//*[@class='list issues']/tbody/tr[" + (j + 1) + "]/td[5]")).Text;
                            Console.WriteLine(Issue_Subject);
                        }
                    
    
                        driver.findElement(By.xpath(".//*[@class='next']")).click();
                    }
        
                }
            }
        }
