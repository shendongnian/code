    [HttpPost]
    public ActionResult Index(HttpPostedFileBase file) {
            
      if (file.ContentLength > 0) {
        var fileName = Path.GetFileName(file.FileName)
                           .Replace(" ","");
        var finalName=String.Format("{0:yyyyMMddHHmm}._{1}",DateTime.Today,fileName);
        var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), finalName);
        file.SaveAs(path);
      }
            
      return RedirectToAction("Index");
    }
