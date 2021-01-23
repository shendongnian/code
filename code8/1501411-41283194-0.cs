    public class FileInfo
    {
        public string FilePath { get; private set; }
        public string Numbers { get; private set; }
        public FileInfo(string filepath)
        {
            var fileName = Path.GetFileName(filepath);
            if (!fileName.StartsWith("NCR"))
            {
                throw new ArgumentException("Wrong type of file.");
            }
            FilePath = filepath;
            var nameParts = fileName.Split('_');
            Numbers = nameParts[3] + nameParts[4];
        }
    }
