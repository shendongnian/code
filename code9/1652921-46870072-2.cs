    using (var memoryStream = new MemoryStream())
    {
        using (var zip = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
        {
            for (var i = 0; i < images.Length; i++)
            {
                var img = images[i];
                var file = zip.CreateEntry(i + ".bmp");
                using (var stream = new MemoryStream())
                {
                    img.Save(stream, ImageFormat.Bmp);
                    using (var entryStream = file.Open())
                    {
                        var bytes = stream.ToArray(); -- to keep it as image better to have it as bytes
                        entryStream.Write(bytes, 0, bytes.Length); 
                    }
                }
            }
        }
    
        using (var fileStream = new FileStream(@"test.zip", FileMode.Create))
        {
            memoryStream.Seek(0, SeekOrigin.Begin);
            memoryStream.CopyTo(fileStream);
        }
    }
