    [HttpGet]
    public IActionResult DownloadCarousel(string name)
    {
        File zip = MediaService.GetCarousel(name, ZipFolder);
        Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{zip.Name}.zip\"");
        return File(zip.Content, "application/zip");
    }
