    [AjaxOnly, AllowAnonymous]
    public ActionResult CheckExistingEmail(string emailWithoutExtension, string emailWithExtension, string emailExtension)
    {
        if(string.IsNullOrEmpty(emailWithoutExtension) && string.IsNullOrEmpty(EmailWithExtension))
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    	
    	var email = string.Emtpy;
    	if(!string.IsNullOrEmpty(emailWithoutExtension)) && !string.IsNullOrEmpty(emailExtension))
    	{
    		email = emailWithoutExtension + emailExtension;
    	}
    	
    	if(!string.IsNullOrEmpty(emailWithExtension) && string.IsNullOrEmpty(emailWithoutExtension))
    	{
    		email = emailWithExtension;
    	}
    	
        var account = AccountManager.FindByEmail(email);
        if (account == null)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    
        return Json("Email already exists try another.", JsonRequestBehavior.AllowGet);
    }
