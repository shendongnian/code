    [HttpPost]
    public ActionResult Edit(updown viewModel, HttpPostedFileBase file)
    {
        var currentupdown = db.updowns.Find(viewModel.id);
        if (file != null)
        {
            var existingFile = Path.Combine(Server.MapPath("~/App_Data/upload"),currentupdown.upload);
             if (System.IO.File.Exists(existingFile))
             {
                 System.IO.File.Delete(existingFile)
            }
            var fileName = Guid.NewGuid() + Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/App_Data/upload"), fileName);
            file.SaveAs(path);
            currentupdown.upload = fileName;   // Update to the new file name
        }
        currentupdown.keterangan = viewModel.keterangan;
        db.SaveChanges();
        return RedirectToAction("List", "Home");
    }
