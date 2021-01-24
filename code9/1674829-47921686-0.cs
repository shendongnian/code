    [Binding]
    class MySteps
    {
        private readonly SeleniumContext _seleniumContext;
        public MySteps(SeleniumContext seleniumContext)
        {
            _seleniumContext = seleniumContext;
        }
        [AfterScenario()]
        public void AfterScenario()
        {
            _seleniumContext.Driver.Quit();
        }
