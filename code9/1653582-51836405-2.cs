        [HttpPost("UploadSingleFile")]
        public async Task<IActionResult> Post(IFormFile file)
        {
        
            // Full path to file in temp location
            var filePath = Path.GetTempFileName();
            if (file.Length > 0)
                using (var stream = new FileStream(filePath, FileMode.Create))
                    await file.CopyToAsync(stream);
            // Process uploaded files
            return Ok(new { count = 1, path = filePath});
        }
