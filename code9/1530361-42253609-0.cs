    // Calculate a path for your cache file.
    var compressedCacheFilename = GetCachePath(filename);
    Stream compressedStream;
    if (File.Exists(compressedCacheFilename)) {
        compressedStream = new FileStream(compressedCacheFilename, FileMode.Open, FileAccess.Read);
    }
    else {
        /* Use the best compression algorithm for your data
           and store it to the corresponding path. */
        compressedStream = compressor.CompressTo(
            new FileStream(filename, FileMode.Open, FileAccess.Read),
            compressedCacheFilename
        );
    }
    
    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
    response.Content = new StreamContent(compressedStream);
    response.Content.Headers.ContentType = "application/json";
    response.Content.Headers.ContentEncoding.Clear();
    response.Content.Headers.ContentEncoding.Add("gzip"); // your compression algorithm
