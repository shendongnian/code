    public ActionResult Index()
    {
    var GetWebConfigValue1 = System.Configuration.ConfigurationManager.AppSettings["WebConfigValue1"].ToString();
    
        ViewBag.WebConfigValue1 = GetWebConfigValue1;
        // Repeat the lines of code above to get more values
    
        return View();
    
    }
