    [HttpPost, ValidateModel]
    public async Task<File> SaveCarousel([FromBody]CarouselViewModel model)
    {
        return await MediaService.ZipCarouselAsync(model.Images, ZipFolder);
    }
