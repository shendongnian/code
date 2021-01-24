    [HttpPost]
    [Route("MediaUpload")]
    [DisableFormValueModelBindingAttribute]
    public async Task<HttpResponseMessage> MediaUploadAsync(string Id, [FromQuery]string sessionId)
    {
    	AppSettings config = new AppSettings();
    	var importConfig = config.GetImportConfig();
    	var localPath = importConfig["ImportImageFolderPath"];
    	FormOptions _defaultFormOptions = new FormOptions();
    	List<MediaInfo> listMedia = new List<MediaInfo>();	
    	if (!Helpers.MultipartRequestHelper.IsMultipartContentType(Request.ContentType))
    	{
    		throw new GetDataException("Unsupported Media Type");
    	}
    	var boundary = MultipartRequestHelper.GetBoundary(MediaTypeHeaderValue.Parse(Request.ContentType), _defaultFormOptions.MultipartBoundaryLengthLimit);            
    	var reader = new MultipartReader(boundary, HttpContext.Request.Body);
    	var section = await reader.ReadNextSectionAsync();
    	StreamReader stream = new StreamReader(section.Body, Encoding.UTF8);
    	// READ FORM DATA
    	if (section.ContentDisposition.Contains("MediaInfo"))
    	{
    		var data = stream.ReadLine();
    		listMedia = JsonConvert.DeserializeObject<List<MediaInfo>>(data);                
    	}
    	
    	CreateMediaOutput mediaOutput = new CreateMediaOutput(listMedia[0], localPath);
    	
    	// READ IMAGE FILES
    	if (section.ContentType == "image/jpeg")
    	{
    		while ((section = await reader.ReadNextSectionAsync()) != null)
    		{
    			var file = section.AsFileSection().FileName;
    			string fullPath = Path.Combine(localPath, file);
    			FileInfo fileInfo = new FileInfo(fullPath);
    			using (var fileStream = new FileStream(fullPath, FileMode.Create))
    			{
    				await section.Body.CopyToAsync(fileStream);
    			}
    			mediaOutput.BusnLogicHere(fileInfo, sessionId);	// internal busn logic..
    		}
    	}                        
    	HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.Accepted);
    	return msg;
    }
