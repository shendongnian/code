    static string RemoveChildText(IWebElement parent)
    {
        string text = parent.Text;
        foreach (IWebElement e in parent.FindElements(By.CssSelector("*")))
        {
            text = text.Replace(e.Text, "");
        }
        return text.Trim();
    }
