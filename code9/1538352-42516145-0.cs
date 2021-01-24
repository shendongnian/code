    public class SeleniumController
    {
        public static readonly SeleniumController Instance = new SeleniumController();
        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);
    
        public IWebDriver Selenium { get; private set; }
    
        private void Trace(string message) { Console.WriteLine("-> {0}", message); }
    
        public void Start()
        {
            if (Selenium != null)
                return;
    
            string appUrl = ConfigurationManager.AppSettings["AppUrl"];
    
            var options = new ChromeOptions();
            options.AddArgument("test-type");
            Selenium = new ChromeDriver(options);
            Selenium.Manage().Timeouts().ImplicitlyWait(DefaultTimeout);
    
            Trace("Selenium started");
        }
    
        public void Stop()
        {
            if (Selenium == null) return;
    
            try
            {
                Selenium.Quit();
                Selenium.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "Selenium stop error");
            }
            Selenium = null;
            Trace("Selenium stopped");
        }
    }
