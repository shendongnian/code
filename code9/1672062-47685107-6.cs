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
    public static class SettingMobule
    {
        public static FileType TxtFileType { get; } = new FileType(1, "txt", true);
        public static FileType CsvFileType { get; } = new FileType(10, "csv", false);
        public static FileType HexFileType { get; } = new FileType(3, "hex", true);
    }
