    IList<IWebElement> prices = driver.FindElements(By.Xpath("//span[class="item_price" and not(span[contains(@style,'font-size')])]"));
    
            foreach (var correctPrice in prices)
            {
                { Console.Write(correctPrice.Text); }
    
