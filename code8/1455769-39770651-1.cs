    public ActionResult Index()
    {
        Profile p = new Profile();
        string sample=p.PrintResult();
    
        return View((object)sample);
    }
