    const string sessionVariableName = "num";
    public ActionResult ClickCounter()
    {
       if (Session[sessionVariableName] == null)
       {
            Session[sessionVariableName] = 0;
       }
       return View();
    }
    [HttpPost]
    public ActionResult ClickCounter(string dummyParam)
    {       
        if (Session[sessionVariableName] == null) // should not happen!
        {
            Session[sessionVariableName] = 0;
        }
        else
        {
            var n = (int)Session[sessionVariableName];
            n++;
            Session[sessionVariableName] = n;
        }
       return View();
    }
