     [HttpGet]
    public ActionResult LoanSearch(string q, Member loanss)
    {
    try
    {
        var loans = GetLoans(q, loanss);
        return PartialView(loans);
    }
      catch(NullReferenceException)
    { 
           return PartialView(ErrorPage);
    }
    }
    
