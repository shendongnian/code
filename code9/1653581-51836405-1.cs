        // Of course this action exist in microsoft docs and you can read it.
        HttpPost("UploadMultipleFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
        
            long size = files.Sum(f => f.Length);
            // Full path to file in temp location
            var filePath = Path.GetTempFileName();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                    using (var stream = new FileStream(filePath, FileMode.Create))
                        await formFile.CopyToAsync(stream);
            }
            // Process uploaded files
            return Ok(new { count = files.Count, path = filePath});
        }
