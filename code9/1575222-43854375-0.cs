    [HttpPost]
    public ActionResult FileUpload(HttpPostedFileBase file)
    {
        if (file != null)
        {
             // Moved this inside the conditional because you can't
             // reference `file.FileName` unless `file` is non-null
             Debug.WriteLine(file.FileName);
             var fileName = Path.GetFileName(file.FileName);
             pathName = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
             file.SaveAs(pathName);
             return RedirectToAction("Index");
         }
    
         // Traditionally, you'd pass in what was posted to the call to `View`,
         // but you cannot repopulate a file input, so there's no point here.
         return View();
     }
