    public async Task<IActionResult> UploadImage(IFormFile image)
    {
        using (var stream = new MemoryStream())
        {
            // image is IFormFile
            await image.CopyToAsync(stream);
    
            StripExif(stream);
    
            // save stream
        }
    
        return Ok();
    }
    
    public static void StripExif(Stream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);
    
        // remove Exif data
    }
