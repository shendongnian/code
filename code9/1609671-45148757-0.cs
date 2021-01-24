        [HttpPost]
        public async Task<IActionResult> ReadFileHeaders(IFormFile file)
        {
            if (file != null)
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    // Now the file is loaded into the stream variable
                }
            }
            return BadRequest("File required");
        }
