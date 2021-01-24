    public static class SeleniumSupport
    {
        private static bool ReuseWebSession
        {
            get { return ConfigurationManager.AppSettings["ReuseWebSession"] == "true"; }
        }
    
        [BeforeScenario("web")]
        public static void BeforeWebScenario()
        {
            SeleniumController.Instance.Start();
        }
    
        [AfterScenario("web")]
        public static void AfterWebScenario()
        {
            if (!ReuseWebSession)
                SeleniumController.Instance.Stop();
        }
    }
