    static void Main()
    {
        var driver = new ChromeDriver();
        var vehicleGroupInputElements = driver.FindElements(By.ClassName("vehGrp"));
        var vehicleGroupNames = vehicleGroupElements
            .Select(GetParent)
            .Select(e => e.Text)
            .ToArray();
    }
    public static IWebElement GetParent(IWebElement e)
    {
        return e.FindElement(By.XPath(".."));
    }
