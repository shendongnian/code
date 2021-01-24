    public ActionResult Purchase()
    {
        //Check to see if these values have been assigned via Login Controller Action
        if(Session["Account_ID"] == null || Session["Account_UserName"] == null)
        {
             //If so, redirect to Controller Action where user can log into.
             RedirectToAction("Index", "Account")
        }
        else
        {
             //Make Purchase occur.
        }
    }
