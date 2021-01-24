    [HttpPost]
    [Route("documents/upload")]
    public async Task<IActionResult> Post(List<IFormFile> files)
    {
        long size = files.Sum(f => f.Length);
    
        // full path to file in temp location
        var filePath = Path.GetTempFileName();
    
        foreach (var formFile in files)
        {
            if (formFile.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
        }
    
        // process uploaded files
        // Don't rely on or trust the FileName property without validation.
    
        return Ok(new { count = files.Count, size, filePath});
    }
