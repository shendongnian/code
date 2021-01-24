    [HttpPost]
    public IActionResult FetchUploadProgress(string progressId)
    {
    	var progressPercent = HttpContext.Session.GetInt32(progressId);
    
    	return Ok(new
    	{
    		progressPercent
    	});
    }
    
    [HttpPost]
    [ActionName("upload")]
    public async Task<IActionResult> TempStoreMp3File(IFormFile file, string progressId)
    {
    	var processAudio = await _fileStorage.TempStoreMp3Data(file);
    	var audioBlob = _cloudStorage.GetBlob(CloudStorageType.Audio, processAudio.AudioName);
    
    	HttpContext.Session.SetInt32(progressId, 50);
    
    	return RedirectToAction(nameof(Upload), new
    	{
    		audioName = processAudio.AudioName,
    		audioPath = processAudio.AudioPath,
    		progressId
    	});
    }
    
    [HttpGet]
    public async Task<IActionResult> Upload(string audioName, string audioPath, string progressId)
    {
    	var audioBlob = _cloudStorage.GetBlob(CloudStorageType.Audio, audioName);
    
    	await audioBlob.UploadFromPathAsync(audioPath, ProcessAudio.AudioContentType);
    	HttpContext.Session.SetInt32(progressId, 100);
    
    	return Ok();
    }
