    [FindsBy(How = How.XPath, Using = "html/body/div/div[2]/div/div[1]/div[1]/ul/li")]
    public IList<IWebElement> Lists { get; set; }
    public SeleniumPage()
    {
        foreach (IWebElement List in Lists)
        {
            List.ChinsayClick();
            System.Threading.Thread.Sleep(2000);
        }
        return new SeleniumPage();
    }
