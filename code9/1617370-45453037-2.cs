    public ActionResult ViewOnline(string FileID)
    {
        int CurrentFileID = Convert.ToInt32(FileID);
        var filesCol = obj.GetFiles();
        string fullFilePath = (from fls in filesCol
                                    where fls.FileId == CurrentFileID
                                    select fls.FilePath).First();
        string text = System.IO.File.ReadAllText(fullFilePath);
        return Content(text);
    }
