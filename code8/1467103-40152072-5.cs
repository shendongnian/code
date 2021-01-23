    public ActionResult Index()
        {
    	    private string usersFullName = UserPrincipal.Current.DisplayName;
    		UserViewModel objCls=new UserViewModel();
    		objCls.userFullName=usersFullName;
            return View(objCls);
        }
	
