    public class AvailableFile {
        private readonly IDirectory directory;
        public AvailableFile (IDirectory directory) {
            this.directory = directory;
        }
        public void GetAvailableFiles(string rootFolder) {
           string[] files = directory.GetFiles(rootFolder);
           //...other code using files
        }
    }
