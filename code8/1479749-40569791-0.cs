    public interface IFileProvider
    {
        UploadResult UploadFile(byte[] fileContent, string fileName);
        DownloadResult DownloadFile(int fileId);
    }
