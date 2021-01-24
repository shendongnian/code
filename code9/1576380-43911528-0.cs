    try
                {
                    List<IWebElement> frames = new List<IWebElement>(driver.FindElements(By.TagName("iframe")));
                    driver.SwitchTo().Frame(1);
                    //Verification point to see "Send an Invite" link has opened by checking Text Name textbox is present or not by using CSS selector
                    if (IsElementPresent(By.CssSelector("#FirstName")))
                    {
                        ExtentManager.verifySafely(driver.FindElement(By.CssSelector("#FirstName")).TagName, "input", "VerifySendAnInviteLink", "link has opened ", driver);
                        Console.WriteLine("'Send an Invite' link has opened ");
                    }
