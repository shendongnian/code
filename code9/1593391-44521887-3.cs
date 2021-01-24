    [HttpPost, ValidateModel]
    public async Task<IActionResult> DownloadCarousel([FromBody]CarouselViewModel model) {
        File zip = await MediaService.DownloadAndZipCarousel(model.Images, BaseServerPath);
        var filename = $"{zip.Name}.zip";
        Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{filename}\"");
        return File(zip.Content, "application/zip", filename);
    }
