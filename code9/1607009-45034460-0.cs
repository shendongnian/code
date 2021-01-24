    public HttpResponseMessage GetFileResponse(byte[] bytes, string fileName, HttpRequestMessage request)
    {
    	HttpResponseMessage result = null;
    
    	Stream stream = new MemoryStream(bytes);
    
    	result = request.CreateResponse(System.Net.HttpStatusCode.OK);
    	result.Content = new StreamContent(stream);
    	result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
    	result.Content.Headers.ContentDisposition.FileName = fileName;
    
    	return result;
    }
