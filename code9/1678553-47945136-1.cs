    [Route("DownloadFiles")]
    [HttpGet]
    public HttpResponseMessage DownloadFiles()
    {
        var files = ...;
        return ZipContentResult(files);
    }
    
    protected HttpResponseMessage ZipContentResult(IEnumerable<Asset> files)
    {
        var pushStreamContent = new PushStreamContent((stream, content, context) =>
        {
            using (var zipOutputStream = new ZipOutputStream(stream))
            {
                zipOutputStream.SetLevel(0); // 0 - store only to 9 - means best compression
    
                foreach (var file in files)
                {
                    var entry = new ZipEntry(file.FilenameSlug())
                    {
                        DateTime = DateTime.Now,
                        Size = file.Filesize
                    };
                    zipOutputStream.PutNextEntry(entry);
                    storageService.ReadToStream(file, zipOutputStream);
                    stream.Flush();
                 }
                 zipOutputStream.Finish();
                 zipOutputStream.Close();
            }
            stream.Close();
        }, "application/zip");
    
        return new HttpResponseMessage(HttpStatusCode.OK) { Content = pushStreamContent };
    }
