private ActionResult CreateZip(IEnumerable<FileContentResult> files)
{
    if (files.Any())
    {
        MemoryStream zipStream = new MemoryStream();
        using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create, false))
        {
            foreach (var f in files)
            {
               var entry = archive.CreateEntry(f.FileDownloadName, CompressionLevel.Fastest);
               using (var entryStream = entry.Open())
               {
                   entryStream.Write(f.FileContents, 0, f.FileContents.Length);
                   entryStream.Close();
               }
           }
           
        }
        zipStream.Position = 0;
        return File(zipStream, MediaTypeNames.Application.Zip, "horta.zip");
    }
    return new EmptyResult();
}
