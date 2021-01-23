    string availableTime = null;
    // Find all elements with class = 'day-num'
    var dayNums = selenium.WebDriver.FindElements(By.XPath("//span[@class='day-num']"));
    foreach (IWebElement dayNum in dayNums)
    {
        // check if text is equal to 6
        if (dayNum.Text == "6")
        {
            // get the following sibling with class = 'available-time', then get the text
            availableTime = dayNum.FindElement(By.XPath("following-sibling::span[@class='available-time']")).Text; 
            break;
        }
    }
