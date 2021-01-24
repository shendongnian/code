    public FileResult TestDownload()
    {
        HttpContext.Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        FileContentResult result = new FileContentResult(System.IO.File.ReadAllBytes("YOUR PATH TO DOC"), "application/msword")
        {
            FileDownloadName = "myFile.docx"
        };
    
        return result;                                
    }
