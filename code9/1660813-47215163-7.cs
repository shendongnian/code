    [HttpPost]
    public ActionResult Edit(updown viewModel, HttpPostedFileBase file)
    {
        var currentupdown = db.updowns.Find(viewModel.id);
        if (file != null)
        {
           var location=Server.MapPath("~/App_Data/upload");
            //Delete existing file
           if (!string.IsNullOrEmpty(currentupdown.upload))
           {
               var existingFile= Path.Combine(location, currentupdown.upload);
               if (System.IO.File.Exists(existingFile))
               {
                   System.IO.File.Delete(existingFile);
               }
           }
           var fileName = Guid.NewGuid() + Path.GetFileName(file.FileName);
           var path = Path.Combine(location, fileName);
           file.SaveAs(path);
           currentupdown.upload = fileName;   // Update to the new file name
        }
        currentupdown.keterangan = viewModel.keterangan;
        db.SaveChanges();
        return RedirectToAction("List", "Home");
    }
