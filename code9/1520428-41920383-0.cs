    IList<IWebElement> allElement = driver.FindElements(By.TagName("td"));
     foreach (IWebElement element in allElement )
     {
        string cellText= element.Text;
        Console.WriteLine(cellText);
     }
