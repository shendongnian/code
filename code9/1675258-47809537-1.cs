    public ActionResult TestPDF(List<int> fileid)
    {
        var myModel = new List<UploadedFile>();
        foreach (var id in fileid)
        {          
            myModel.Add(db.UploadedFiles.Find(id));
        }
        return View(myModel);
    }
