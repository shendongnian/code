    [HttpPost]
    public async Task<IActionResult> Upload(ICollection<IFormFile> files)
    {
        try
        { 
            if (await _contextPB.UploadRow.AnyAsync())
            {
                Danger(string.Format("Please LOAD the existing containers before uploading another file"), true);
                return View();
            }
            
            // your code
        }
        catch (Exception ex)
        {
            // what is the error?
            // add a breakpoint to see
            throw;
        }
    }
