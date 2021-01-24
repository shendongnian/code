     public ValuesController()
        {
            LogFourNet.SetUp(Assembly.GetEntryAssembly(), "log4net.config");
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            LogFourNet.Info(this, "This is Info logging");
            LogFourNet.Debug(this, "This is Debug logging");
            LogFourNet.Error(this, "This is Error logging");
           
            
            return new string[] { "value1", "value2" };
        }
