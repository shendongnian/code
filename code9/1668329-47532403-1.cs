    [Binding]
    public class Setup
    {
    public static IWebDriver Driver = new ChromeDriver();
    [BeforeTestRun]
    public static void SetUpBrowser()
    {
    Driver.Manage().Window.Maximize();
    }
