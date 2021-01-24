    public class FileType
    {
        public FileType(int startingRow, string extension, bool skipEmpty)
        {
            this.StartingRow = startingRow;
            this.Extension = extension;  // 'FileType': Member names cannot be the same as their
                                         // enclosing type.
            this.SkipEmpty = skipEmpty;
        }
        public int StartingRow { get; }
        public string Extension { get; }
        public bool SkipEmpty { get; }
    }
