    public ActionResult TestPDF(List<int> fileid)
    {
        List<Upload.Models.UploadedFile> myModel = fileid == null ? new List<Upload.Models.UploadedFile>() : db.UploadedFiles.Where(o => fileid.Contains(o.ID)).ToList();
    
        return View(myModel);
    }
