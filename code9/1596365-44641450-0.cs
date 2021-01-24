      public static void WaitUntilInvisible(this By locator)
            {
                try
                {
                    if (Driver.FindElement(locator).Displayed)
                    {
                        wait.Until(ExpectedConditions.ElementIsVisible(locator));
                    }
            }
