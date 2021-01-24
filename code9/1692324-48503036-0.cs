        [HttpPost("upload_blob")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            Console.WriteLine(file.ContentType);
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return Ok("some result");
        }
