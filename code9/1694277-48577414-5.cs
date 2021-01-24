    public ActionResult Index(UserCustom userCustomModel = null)
    {
        //initialize only if null
        if ( userCustomModel == null )
        {
           userCustomModel = new UserCustom();
        }
        // end load customer
        var res = db.Users.ToList(); // select all users from the database
        userCustomModel.PageSize = 10;
        userCustomModel.PageCount = ((res.Count() + userCustomModel.PageSize - 1) / userCustomModel.PageSize);
                                    // (7 + 5 - 1)  = 11 / 5 = 2 pages
        if (userCustomModel.CurrentPageIndex > userCustomModel.PageCount)
        {
            userCustomModel.CurrentPageIndex = userCustomModel.PageCount;
        }
        userCustomModel.user = res.Skip(userCustomModel.CurrentPageIndex * userCustomModel.PageSize).Take(userCustomModel.PageSize);
                  // 0 * 5 = 0 (5) 
                  // 1 * 5 = 5 skip 5.take 5-10
        userCustomMode.userDDL = res;
       
        return View(userCustomModel);
	}
    
