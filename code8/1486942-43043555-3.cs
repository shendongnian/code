    [HttpPost]
    public void UploadFiles()
    {
         var filesToDelete = HttpContext.Current.Request.Params["filesToDelete"];
         var clientContactId= HttpContext.Current.Request.Params["clientContactId"];
         //Your code here...
    }
