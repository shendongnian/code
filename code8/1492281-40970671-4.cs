    [HttpPost]
    public async Task<HttpResponseMessage> SaveFile(long docId)
    {
    	HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Unauthorized);
    	try
    	{
    		var filedata = await Request.Content.ReadAsMultipartAsync(new MultipartMemoryStreamProvider());
    		foreach(var file in filedata.Contents)
    		{
    			var fileStream = await file.ReadAsStreamAsync();
    		}
    
    		response = Request.CreateResponse<bool>(HttpStatusCode.OK, true);
    	}
    	catch (Exception ex)
    	{
    		response = Request.CreateResponse<bool>(HttpStatusCode.InternalServerError, false);
    	}
    	return response;
    }
