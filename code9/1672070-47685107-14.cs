    public class FileType
    {
        public FileType(int startingRow, string extension, bool skipEmpty)
        {
            this.StartingRow = startingRow;
            this.Extension = extension;
            this.SkipEmpty = skipEmpty;
        }
        public int StartingRow { get; }
        public string Extension { get; }
        public bool SkipEmpty { get; }
    }
