    public ActionResult Test2()
    {
        if (Request.Browser.IsMobileDevice)
        {   return View("~/Views/Test/Test.Mobile.cshtml", new TestModel()); }
        else
        {   return View("~/Views/Test/Test.cshtml", new TestModel()); }
    }
