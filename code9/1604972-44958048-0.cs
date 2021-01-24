    public ActionResult HeaderUserInfo()
    {
    	var user = _workContext.CurrentUser; //get info about user
    	var model = new HeaderUserInfoModel
    	{
    		Username = user.Username,
    		UserId = user.Id
    	};
    	return PartialView(model);
    }
