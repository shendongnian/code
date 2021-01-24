    public FileResult Download(string fileName)
    {
        // other stuff
        // read all contents from source file
        string path = Path.Combine(Server.MapPath("~/App_Data/uploads/"), fileName);
        // set content type, e.g. 'application/pdf' for PDF files
        // or use 'System.Net.Mime.MediaTypeNames' to get predefined content types
        string contentType = MimeMapping.GetMimeMapping(path);
        // return FilePathResult to download
        return File(path, contentType, fileName);
    }
