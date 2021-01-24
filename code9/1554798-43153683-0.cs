    public ActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public ActionResult Index(string data)
    {
        int ruleKey = Convert.ToInt32(data);
        Helper helper = new Helper();
        helper.RevalidateRule(ruleKey);
        return View();
    }
