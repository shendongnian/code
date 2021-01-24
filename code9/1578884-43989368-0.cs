    public static void ClickListItemByNameVirtualization(IWebDriver browser, IWebElement ulElem, IWebElement divElem, string itemName)
            int scrollAmount = 0;
            IJavaScriptExecutor js = (IJavaScriptExecutor)browser;
            ProgramLibraryPage PL = new ProgramLibraryPage(browser);
            PL.ChangeProgFormSelectProgDrpDnBtn.Click();
            // Scroll to the top of the list
            js.ExecuteScript("return arguments[0].scrollTop = 0;", divElem);
            for (var i = 0; i < 1000; i++)
            {
                List<IWebElement> liElems = ulElem.FindElements(By.TagName("li")).ToList();
                foreach (var liElem in liElems)
                {
                    // if the current list item's text value in the for loop equals the users passed parameter itemName
                    if (liElem.Text == itemName)
                    {
                        liElem.Click();
                        Thread.Sleep(0200);
                        return;
                    }
                }
                scrollAmount = scrollAmount + 387;
                object scrollMaxHeight = js.ExecuteScript("return arguments[0].scrollHeight;", divElem);
                var scrollMaxHeightInt = Convert.ToInt32(scrollMaxHeight);
                if (scrollMaxHeightInt > scrollAmount)
                {
                    ElemSet.ScrollToWithinFrame(browser, divElem, scrollAmount, "Vertical");
                }
            }
    }
