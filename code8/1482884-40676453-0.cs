    [HttpPost]
    public ActionResult Index(HttpPostedFileBase file) {
     // Verify that the user selected a file
     if (file != null && file.ContentLength > 0) {
      // extract only the filename
      var fileName = Path.GetFileName(file.FileName);
      // store the file inside ~/App_Data/uploads folder
      var path = Path.Combine(Server.MapPath("~/Images/Item"), fileName);
      file.SaveAs(path);
     }
    
     return RedirectToAction("Index");
    }
