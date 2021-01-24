    public IActionResult TestReport() {        
        var document = HelloWorld();
        using (var memoryStream = new MemoryStream()) {
            document.Save(memoryStream, false);
            var buffer = memoryStream.GetBuffer();
            var contentDisposition = new ContentDispositionHeaderValue("attachment");
            contentDisposition.SetHttpFileName("helloWorld.pdf");
            Response.Headers[HeaderNames.ContentDisposition] = contentDisposition.ToString();
            return File(buffer, "application/pdf");
        }            
    }  
