    var memoryStream = new MemoryStream();
    var response = new HttpResponseMessage(HttpStatusCode.OK);
    List<string> filepaths = await GetSomeFiles();
    using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
    {
        foreach (string filepath in filepaths)
        {
             string filename = Path.GetFileName(filepath);
             var entry = archive.CreateEntry(filename);
             using (var file = File.OpenRead(filename))
             using (var entryStream = entry.Open())
             {
                  await file.CopyToAsync(entryStream);
             }
        }
    }
    memoryStream.Position = 0;
    response.Content = new StreamContent(memoryStream);
    response.Content.Headers.ContentLength = memoryStream.Length;
    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
    {
        FileName = "TheFile.zip")
    };
    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
    return response;
