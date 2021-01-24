    public class FilesystemServiceAndroid : IFilesystemService
    {
        public string GetAppRootFolder()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        }
    }
