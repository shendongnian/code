    [HttpPost]
    public ActionResult Create(MediaVm model)
    {
      if (ModelState.IsValid)
      {
          var fileName = SaveAndReturnFileName(model.Img);
          var m = new Media { title = model.Title, body, model.Body};
          m.ImagePath = fileName;
          db.Medias.Add(m);
          db.SaveChanges();
          return RedirectToAction("Index");
      }
      return View(model);
    }
    public string SaveAndReturnFileName(HttpPostedFileBase file)
    {
        if (file == null)
            return null;
    
        var fileName = Path.GetFileName(file.FileName);
        string randomFileName = Path.GetFileNameWithoutExtension(fileName) +
                            "_" +
                            Guid.NewGuid().ToString().Substring(0, 4) 
                                + Path.GetExtension(fileName);
        var path = Path.Combine(Server.MapPath("~/Content/Upload/"), randomFileName);
        file.SaveAs(path);
        return randomFileName;
    }
