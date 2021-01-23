    public async Task<IActionResult> UploadImage(IFormFile image)
    {
        using (var stream = new MemoryStream(),
               var writer = new StreamWriter(new MemoryStream()))
        {
            // image is IFormFile
            await image.CopyToAsync(stream);
    
            var strippedStream = StripExif(stream, writer);
    
            // save strippedStream, not stream.
        }
    
        return Ok();
    }
    
    public static void StripExif(MemoryStream stream, StreamWriter writer)
    {
        var result = new MemoryStream();
    
        // lets assume for sake of example that removing ExIf just removes the
        // the first 10 characters of the stream
        stream.Seek(10, SeekOrigin.Begin);
    
        writer.Write(stream.ReadToEnd());        
    }
