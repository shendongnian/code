     [HttpGet]
    public ActionResult LoanSearch(string q, Member loanss)
    {
    try
    {
        var loans = GetLoans(q, loanss);
        return PartialView(loans);
    }
      catch(NullReferenceException e)
    {
    //any of your choice
          ModelState.AddModelError("Nothing Found", "Sorry nothing Found");
          RedirectToAction("ReferenceError")  
    }
    }
    
    public ActionResult ReferenceError()
    {
    return View();
    }
