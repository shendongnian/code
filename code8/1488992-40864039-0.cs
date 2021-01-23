    public ActionResult ReportTable()
    {
      var yourmodel=new List<YouModelType>(); /// generate model
      return View(yourmodel);//// pass model parameter to view
    }
