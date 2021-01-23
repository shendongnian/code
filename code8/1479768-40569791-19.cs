    public class FileSystemFileProvider : IFileProvider
    {
        public FileSystemFileProvider(string absouteBasePath)
        {
            //Check if absoluteBasPath exists and create the directory if it doesn't.
            if (!Directory.Exists(absouteBasePath))
                Directory.CreateDirectory(absouteBasePath);
        }
        public UploadResult UploadFile(byte[] fileContent, string fileName)
        {
            //TODO: Your upload file implementation here
        }
        public DownloadResult DownloadFile(int fileId)
        {
            //TODO Your download file implementation here
        }
    }
