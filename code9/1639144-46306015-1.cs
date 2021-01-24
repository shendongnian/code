    [HttpGet]
    public ActionResult GetPDF(string pdf)
    {
        string filepath = "C:\\inetpub\\wwwroot\\Projects\\Attachments\\Invoice_2424.pdf"";
       
        byte[] filedata = System.IO.File.ReadAllBytes(filepath);
        string contentType = MimeMapping.GetMimeMapping(filepath);
    
        var cd = new System.Net.Mime.ContentDisposition
        {
            FileName = filename,
            Inline = true,
        };
    
        Response.AppendHeader("Content-Disposition", cd.ToString());
    
        return File(filedata, contentType);//this is not system.io.File
    }
