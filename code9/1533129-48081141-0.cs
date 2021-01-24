    public virtual ActionResult GetZip()
    {
        var summary = GetBytes();
        var response = new MemoryStream();
        using (var stream = new MemoryStream())
        {
            using (var archive = new ZipArchive(stream, ZipArchiveMode.Create, true))
            {
                var entry = archive.CreateEntry("myfiletozip" + fileExt);
                using (var writer = new BinaryWriter(entry.Open()))
                {
                    writer.Write(summary, 0, summary.Length);
                }
            }
            //Use stream after archive is disposed
            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(response);
        }
        response.Seek(0, SeekOrigin.Begin);
        return this.File(response, MediaTypeNames.Application.Zip, "myzipfilename.zip");
    }
