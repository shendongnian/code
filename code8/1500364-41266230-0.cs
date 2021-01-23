       IList<IWebElement> elements = driver.FindElements(By.XPath("//ul[contains(@class, 'ms-crm-VS-Menu')]/li/a[2]/span/nobr/span"));
            foreach (IWebElement eachelement in elements)
            {
                if (GetInnerHtml(eachelement)=="Create Personal View")
                { break; }
                executor.ExecuteScript("arguments[0].click();", eachelement);
    
                }
            }
    public static string GetInnerHtml(IWebElement element)
    {
        var remoteWebDriver = (RemoteWebElement)element;
        var javaScriptExecutor = (IJavaScriptExecutor) remoteWebDriver.WrappedDriver;
        var innerHtml = javaScriptExecutor.ExecuteScript("return arguments[0].innerHTML;", element).ToString();
    
        return innerHtml;
    }
