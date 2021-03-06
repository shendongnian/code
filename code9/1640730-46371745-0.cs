    public ActionResult Download(string Doc)
    {
    
        string fullPath = Path.Combine(Server.MapPath("~/UploadFiles/"), Doc);
    
        if (fullPath == null)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
    
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, Doc);
        }
        return RedirectToAction("List");
    }
