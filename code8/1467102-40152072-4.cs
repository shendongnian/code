    public ActionResult Index()
        {
    	    private string usersFullName = UserPrincipal.Current.DisplayName;
    		ViewBag.userFullName=usersFullName;
            return View();
        }
