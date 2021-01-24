    [HttpGet]
    public async Task<IActionResult> GetTest()
    {
	    var contentType = "text/plain";
        using (var stream = new MemoryStream(Encoding.ASCII.GetBytes("Hello World")))
        return new FileStreamResult(stream, contentType);
       
    }
