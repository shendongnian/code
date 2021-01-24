    [HttpGet("{container}/{id}")]
    public async Task<IActionResult> Get(string container, string id)
    {
        /* remove both of these headers... put a warning here to apply the fix after dotnet team distributes the fix. */
    	HttpContext.Request.Headers.Remove("If-Modified-Since");
    	HttpContext.Request.Headers.Remove("If-None-Match");
    
    	var _fileInfo = provider.GetFileInfo($"{container}/{id}");
    	if (!_fileInfo.Exists || string.IsNullOrEmpty(id))
    		/* return a default file here */
    
    	var last = _fileInfo.LastModified;
    	/* ... some code removed for brevity */
    	
    	return base.File(_fileInfo.CreateReadStream(), MimeTypeMap.GetMimeType(id.Substring(id.LastIndexOf("."))), id, lastModified: _lastModified, entityTag: _etag);
    }
