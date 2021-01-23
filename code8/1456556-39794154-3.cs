    public AccountController:CustomController
    {
        public ActionResult Index()
        {
            ViewBag.Company = UserCompanies;
            return View();
        }
    }
    
