    [HttpPost()]
    [Consumes("application/zip")]
    [Consumes("application/octet-stream")]
    public async Task<IActionResult> ImportZip()
    {
    	using (var stream = new MemoryStream())
    	{
    		await Request.Body.CopyToAsync(stream);
    	}
    	
    	// do whatever with the file...
    }
