    [HttpGet]
    public HttpResponseMessage Get(string thing1, string thing2) //thing2 will be a string[] eventually, once I am able to get 2-3 pdfs working
    {
        byte[] data = response.PDFBytes[0] == null ? new byte[0] : response.PDFBytes[0];
        int length = response.PDFBytes[0] == null ? 0 : response.PDFBytes[0].Length;
    
        var stream = new MemoryStream(data, 0, length, true, true);
    
        result.Content = new ByteArrayContent(stream.GetBuffer());
    
        result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
        {
            FileName = "CheckedOutItems.pdf"
        };
        string TempPath="~/YourFileTempPath.pdf";
    	using (FileStream file = new FileStream(Server.MapPath(TempPath), FileMode.Create, FileAccess.Write)) {
        stream.WriteTo(file);
    
    	
        return Json(TempPath,JsonBehavior.AllowGet);
    }
