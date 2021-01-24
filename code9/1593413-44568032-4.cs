    [HttpGet]
    public IActionResult DownloadCarousel(string name)
    {
        File zip = CachingService.Get<File>(name);
        if(zip == null) 
        {
            return BadRequest();
        }
        Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{zip.Name}.zip\"");
        return File(zip.Content, "application/zip");
    }
