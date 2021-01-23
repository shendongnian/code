    public class FileReaderService : IFileReaderService
    {
        public string GetFileAsString(string fileName)
        {
            if(!File.Exists(fileName))
                throw new ArgumentException("File Path does not exist.");
            return File.ReadAllText(fileName);
        }
    }
    public interface IFileReaderService
    {
        string GetFileAsString(string fileName);
    }
