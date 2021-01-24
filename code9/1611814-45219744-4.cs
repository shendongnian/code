    public class AvailableFile {
        public void GetAvailableFiles(string rootFolder) {
           string[] files = Directory.GetFiles(rootFolder);
           //...other code using files
        }
    }
