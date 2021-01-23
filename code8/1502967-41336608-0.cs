    using System.IO.Compression.FileSystem; // Reference System.IO.Compression.FileSystem.dll
    
    [HttpGet]
    [Route("api/myzipfile"]
    public dynamic DownloadZip([FromUri]string dirPath)
    {
    if(!System.IO.Directory.Exists(dirPath))
       return this.NotFound();
    
        var tempFile = System.IO.Path.GetTempFileName(); // might want to clean this up if there are a lot of downloads
        ZipFile.CreateFromDirectory(dirPath, tempFile);
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StreamContent(new FileStream(tempFile, FileMode.Open, FileAccess.Read));
        response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
        response.Content.Headers.ContentDisposition.FileName = fileName;
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
    
      return response;
    }
