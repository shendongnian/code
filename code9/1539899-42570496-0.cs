    public ActionResult SignUpIn(string email_acct)
    {
        //pretend i tested for a real user
        TempData["email_acct"] = email_acct;
        var r = new { result = "SingUp", Urls = Url.Action("SingUp") };
        return Json(r);
    }
    
    public ActionResult SingUp()
    {
        if (!TempData.ContainsKey("email_acct"))
        {
            //no temp data email.. maybe redirect.. who knows!!
            return RedirectToAction("Index");
        }
    
        //read the temp data entry.. 
        string emailAcct = TempData["email_acct"].ToString();
    
        //reset the temp data entry
        TempData["email_acct"] = emailAcct;
    
        return View(new SingUpModel { EmailAccount = emailAcct });
    }
