    public static void ClickOnIt(this IWebElement element, string elementName)
    {
        Thread.sleep(3000); // sleep for 3 seconds
        element.Click();
        Console.WriteLine("Clicked on " + elementName);
    }
