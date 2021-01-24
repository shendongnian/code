    [HttpPost, ValidateModel]
    public async Task<IActionResult> SaveCarousel([FromBody]CarouselViewModel model) {
        var token = await MediaService.CacheCarouselAsync(model.Images);
        // Generates /Media/DownloadCarousel?name={token}
        var url = Url.Action("DownloadCarousel","Media", new { name = token });
        var content = new { location = url };
        return Created(url, content);
    }
