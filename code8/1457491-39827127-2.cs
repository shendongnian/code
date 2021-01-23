    [Route("bookshop/{pageName}")]
    public ActionResult MyAction(string pageName)
    {
       // add logic according to what you receive in pageName property
       return View();
    }
