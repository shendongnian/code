    [HttpPost, ValidateModel]
    public async Task<IActionResult> SaveCarousel([FromBody]CarouselViewModel model)
    {
        File zip = await MediaService.ZipCarouselAsync(model.Images, ZipFolder);
    
        if(zip == null)
        {
            return BadRequest();
        }
    
        CachingService.Set<File>(zip.Name, zip);
        return Ok(zip);
    }
