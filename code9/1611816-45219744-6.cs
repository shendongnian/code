    public class DirectoryServie : IDirectory  {
        public string[] GetFiles(string rootFolder) {
            return Directory.GetFiles(rootFolder);
        }
    }
