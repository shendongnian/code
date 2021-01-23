    [HttpPost]
    [ValidateAntiForgeryToken]
    public RedirectResult Upload(HttpPostedFileBase file)
    {
        try
        {
            //physical path there you will save the file. 
            var path = @"c:\temp\filename.txt";
            file.SaveAs(path);
        }
        catch (UploadException ex)
        {
            
        }
        var url = "put here same url or another url";
        return RedirectResult(url);
    }
