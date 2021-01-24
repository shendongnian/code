    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return Content("file not selected");
        else
        {                
            var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot",
                    "processes.json");
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                    
            }
            RetrieveModels rm = rm = new RetrieveModels(path);
            [...]
        }           
    }
