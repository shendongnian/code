    [HttpPost]
    public void UploadFiles()
    {
         var filesToDelete = HttpContext.Current.Request.Params["filesToDelete"];
         var clientContactId= HttpContext.Current.Request.Params["clientContactId"];
         var File = HttpContext.Current.Request.Files["UploadedDocument"]; //Will get the uploaded file
         //Your code here...
    }
