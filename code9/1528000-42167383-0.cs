    public ActionResult Page(object obj)
    {
        Task.Run(() => SQLUploadToDatabase(obj));
    
        string x = DoOtherWork();
    
        return View(x);
    }
