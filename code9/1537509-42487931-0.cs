    [HttpGet()]
    public async Task<HttpResponseMessage> Download()
    {
        string jsonData = "example data";
        byte[] byteArray = Encoding.UTF8.GetBytes(jsonData);
        var stream = new MemoryStream(byteArray);
    
        var result  =  new FileStreamResult(stream, new MediaTypeHeaderValue("text/json"))
                           {
                               FileDownloadName = "testFile.json"
                           };
 
    var httpresult = StringContent(result.ToString(), Encoding.UTF8, "application/json");
    			result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    
    return httpresult;
    }
