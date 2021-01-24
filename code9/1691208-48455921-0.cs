        IReadOnlyCollection<IWebElement> links = driver.FindElements(By.XPath("//*[@id='gb']/div[2]/div[3]/div/div[2]/div/a"));
        if (links.Any() && links.ElementAt(0).Displayed)
        {
            links.ElementAt(0).Click();
            driver.FindElement(By.XPath("//*[@id='gb_71']")).Click();
        }
        else
        {
            Console.WriteLine("Heannaannay");
        }
