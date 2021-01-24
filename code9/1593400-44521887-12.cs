    [HttpGet]
    public async Task<IActionResult> DownloadCarousel(string name) {
        var zip = await MediaService.DownloadAndZipCarousel(name);
        var filename = $"{zip.Name}.zip";
        Response.Headers.Add("Content-Disposition", "attachment; filename=\"{filename}\"");
        return File(zip.Content, "application/zip");
    }
