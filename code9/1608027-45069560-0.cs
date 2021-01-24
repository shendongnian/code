    [HttpGet]
    public FileResult GetPdf()
    {
        var file = new FileInfo(Server.MapPath("~/App_Data/sample.pdf"));
        Response.Headers.Add("content-disposition", $"inline; filename={file.Name}");
    
        /* Return the file from a path
        return File(file.FullName, "application/pdf");
        */
    
        //return the file as binary contents
        var contents = System.IO.File.ReadAllBytes(file.FullName);
        return File(contents, "application/pdf");
    
    }
