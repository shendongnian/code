    [HttpPost]
    public async Task<IActionResult> Post(IFormFile formFile)
    {
        using (Stream stream = formFile.OpenReadStream())
        {
             //Perform necessary actions with file stream
        }
    }
