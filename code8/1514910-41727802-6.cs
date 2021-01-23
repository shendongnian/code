    public async Task<IActionResult> UploadImage(IFormFile image)
    {
        using (var stream = new MemoryStream())
        {
            // image is IFormFile
            await image.CopyToAsync(stream);
    
            var strippedStream = StripExif(stream);
    
            // save strippedStream, not stream.
        }
    
        return Ok();
    }
    
    public static MemoryStream StripExif(MemoryStream stream)
    {
        var result = new MemoryStream();
    
        stream.Seek(0, SeekOrigin.Begin);
    
        // remove Exif data from result
    
        return result;
    }
