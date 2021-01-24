    public class FileType
    {
        public FileType(int startingRow, string fileType, bool skipEmpty)
        {
            this.startingRow = startingRow;
            this.fileType = fileType;
            this.skipEmpty = skipEmpty;
        }
        public readonly int startingRow;
        public readonly string fileType;
        public readonly bool skipEmpty;
    }
    public static class SettingMobule
    {
        public static FileType TxtFileType { get; } = new FileType(1, "txt", true);
        public static FileType CsvFileType { get; } = new FileType(10, "csv", false);
        public static FileType HexFileType { get; } = new FileType(3, "hex", true);
    }
