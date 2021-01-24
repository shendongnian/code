    IList<IWebElement> all = driver.FindElements(By.XPath("//link[@href]"));
    
    String[] allText = new String[all.Count];
    int i = 0;
    foreach (IWebElement element in all)
    {
        allText[i++] = element.Text;
    }
