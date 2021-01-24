    public ActionResult Add(FeedbackRequest feedback)
    {   
        string filepath = "some filepath";
        byte[] filedata = File.ReadAllBytes(filepath);
        string contentType = MimeMapping.GetMimeMapping(filepath);
    
        var contentInfo = new System.Net.Mime.ContentDisposition
        {
            FileName = "download filename",
            Inline = false,//ask browser for download prompt
        };
    
        Response.AppendHeader("Content-Disposition", contentInfo.ToString());
    
        return File(filedata, contentType);
    }
