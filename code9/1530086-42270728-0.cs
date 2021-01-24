    public class FilesController : ApiController
    {
        public IHttpActionResult(Guid fileId)
        {
            var filePath = GetFilePathFromGuid(fileId);
            var fileName = Path.GetFileName(filePath);
            var mimeType = MimeMapping.GetMimeMappting(fileName);
            return OkFileDownloadResult(filePath, mimeType, fileName, this);
        }
    }
