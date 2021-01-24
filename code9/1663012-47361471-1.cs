     public bool IsElementDisplayed(IWebDriver driver, By element)
     {
            for (int i = 1; i <= 5; i++)
            {
                try
                {
                    IReadOnlyCollection<IWebElement> elements = driver.FindElements(element);
                    if (elements.Count > 0)
                    {
                        return elements.ElementAt(0).Displayed;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception was raised on locating element: " + e.Message);
                    Thread.Sleep(1000);
                }
            }
            return false;
     }
