    public class FileType
    {
        public FileType(int startingRow, string fileType, bool skipEmpty)
        {
            this.StartingRow = startingRow;
            this.FileType = fileType;
            this.SkipEmpty = skipEmpty;
        }
        public int StartingRow { get; }
        public string FileType { get; }
        public bool SkipEmpty { get; }
    }
