    public ActionResult Action2(string backUrl)
    {
        if (string.IsNullOrEmpty(backUrl)) 
        { 
            throw new ArgumentNullException("backUrl"); 
        }
        ViewBag.ReturnUrl = backUrl;
        //your work
        return View();
    }
    
    [HttpPost]
    public ActionResult Action2(YourModel model, string backUrl)
    {
        //your work
        return Redirect(backUrl);
    }
