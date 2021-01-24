    //use this dictionary to store the progress for upload
    private static Dictionary<string, int> uploadProgresses = new Dictionary<string, int>();
    
    public IActionResult GetUploadProgress(string uploadId)
    {
        int progress = 0;
        uploadProgresses.TryGetValue(uploadId, out progress);
        return Content(progress.ToString());
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file, string uploadId)
    {
        uploadProgresses.Add(uploadId, 0);
        var processAudio = await _fileStorage.TempStoreMp3Data(file);
        uploadProgresses[uploadId] = 20;
        var audioBlob = _cloudStorage.GetBlob(CloudStorageType.Audio, processAudio.AudioName);
        uploadProgresses[uploadId] = 40;
        await audioBlob.UploadFromPathAsync(processAudio.AudioPath, ProcessAudio.AudioContentType);
        uploadProgresses[uploadId] = 100;
        return Ok();
    }
