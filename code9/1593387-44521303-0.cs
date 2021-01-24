[HttpPost]
public FileResult Download(List<string> files)
{
    var archive = Server.MapPath("~/archive.zip");
    var temp = Server.MapPath("~/temp");
    // clear any existing archive
    if (System.IO.File.Exists(archive))
    {
        System.IO.File.Delete(archive);
    }
    // empty the temp folder
    Directory.EnumerateFiles(temp).ToList().ForEach(f => System.IO.File.Delete(f));
    // copy the selected files to the temp folder
    files.ForEach(f => System.IO.File.Copy(f, Path.Combine(temp, Path.GetFileName(f))));
    // create a new archive
    ZipFile.CreateFromDirectory(temp, archive);
    return File(archive, "application/zip", "archive.zip");}
  [1]: https://www.mikesdotnetting.com/article/306/working-with-zip-files-in-asp-net-mvc
