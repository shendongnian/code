    [HttpPost]
    public ActionResult Index(DemoCLass objdemo)
    {
       if (Request.IsAjaxRequest())
       {
          return PartialView();
       }
       else
       {
          return View();
       }
    }
