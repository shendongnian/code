    public ActionResult ClickCounter()
    {
        const string sessionVariableName = "num";
        if (Session[sessionVariableName] == null)
        {
            Session[sessionVariableName] = count;
        }
        else
        {
            var n = (int)Session[sessionVariableName];
            n++;
            Session[sessionVariableName] = n;
        }
       return View();
    }
