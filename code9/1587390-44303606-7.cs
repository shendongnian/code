    public class FileService : IDirectoryService {
        public IEnumerable<string> EnumerateFiles(string path, string searchPattern) {
            return Directory.EnumerateFiles(path, searchPattern);
        }
    }
