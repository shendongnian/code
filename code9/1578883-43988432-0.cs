    public void ClickListItemByNameVirtualization(IWebDriver browser, IWebElement divElemOfScrollBar, IWebElement ulElemOfDropDown, string itemName)
    {
        var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(5));
        IWebElement lastLi = null;
        while (true) {
            // wait for a new li element at the end and store all li elements
            var liElems = wait.Until<ReadOnlyCollection<IWebElement>>(drv => {
                var elems = ulElemOfDropDown.FindElements(By.TagName("li"));
                return (elems.Count > 0 && elems[elems.Count - 1] != lastLi) ? elems : null;
            });
            // store the last element
            lastLi = liElems[liElems.Count - 1];
            // Loop through all list items
            foreach (var liElem in liElems) {
                // if the current list item's text value in the for loop equals the users passed parameter itemName
                if (liElem.Text == itemName) {
                    liElem.Click();
                    return;
                }
            }
            // scroll the container to the end
            ((IJavaScriptExecutor)browser).js.ExecuteScript(
              "arguments[0].scrollTop = (-1 >>> 1);", divElemOfScrollBar);
        }
    }
