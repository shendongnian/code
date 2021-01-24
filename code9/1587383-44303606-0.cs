    public class FakeDIrectoryService : IDirectoryService {
        IEnumerable<string> files;
        public FakeDIrectoryService(IEnumerable<string> files) {
            this.files = files;
        }
        public IEnumerable<string> EnumerateFiles(string path, string searchPattern = null) {
            return files;
        }
    }
