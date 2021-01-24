    IList<IWebElement> divtag = driver.FindElements(By.XPath("//div"));
    IList<IWebElement> labelstag = driver.FindElements(By.XPath("//label"));
    String[] allText = new String[all.Count];
    int i = 0;
    foreach (IWebElement element in divtag)
    {
        allText[i++] = element.Text;
    }
    
    String[] allText1 = new String[all.Count];
    int y = 0;
    foreach (IWebElement element in labelstag)
    {
        allText1[y++] = element.Text;
    }
