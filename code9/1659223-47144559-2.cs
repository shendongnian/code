    View:
      -Email
        |-Index.cshtml
.
    [HttpGet]
    public ActionResult Index(string userAction, string id)
    {
       ViewBag.returnedValue = "";
    
       if (userAction == "a")
       {
    
       } else if (userAction == "d")
       {
    
       }
    
       return View();
    }
