    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult ApplyOnline([Bind(Include = "Id,JobId,FirstName")] Applied applied, HttpPostedFileBase pmd, int JobId)
    {
      if (ModelState.IsValid)
      {
                //---save the data---------//
                db.MyAppliedContext.Add(applied);
                db.SaveChanges();
                //---Get inserted Id----//
                int insertedId = applied.Id;
                 //--------Upload PMD-------------------//
                if (pmd != null && pmd.ContentLength > 0)
                {
                    try
                    {
                        var PMDFileName = "PMD-" + applied.JobId + "-" + TrimedUser + "-" + insertedId + "-" + pmd.FileName;
                        //var P11FileName = DateTime.Now.ToString();
                        string path = Path.Combine(Server.MapPath("~/App_Data/system"),
                                                   Path.GetFileName(PMDFileName));
                        pmd.SaveAs(path);
                        UploadFiles MyPMDUploads = new UploadFiles();
                        MyPMDUploads.JobId = applied.JobId;
                        MyPMDUploads.ApplyId = insertedId;
                        MyPMDUploads.FileName = Path.GetFileName(PMDFileName);
                        MyPMDUploads.FilePath = path;
                        db.MyUploadFileContext.Add(MyPMDUploads);
                        db.SaveChanges();
                        ViewBag.Message = "PMD uploaded successfully";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR PMD:" + ex.Message.ToString();
                    }
                }
                else
                {
                    ViewBag.Message = "You have not specified a PMD file.";
                }
       }
       return view(Model);
    }
