    public FileResult TestDownload()
    {
        FileContentResult result = new FileContentResult(System.IO.File.ReadAllBytes("YOUR PATH TO DOC"), "application/msword")
        {
            FileDownloadName = "myFile.docx"
        };
        return result;
    }
