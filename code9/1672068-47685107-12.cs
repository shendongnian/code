    public static class SettingModule
    {
        public static FileType TxtFileType { get; } = new FileType(1, "txt", true);
        public static FileType CsvFileType { get; } = new FileType(10, "csv", false);
        public static FileType HexFileType { get; } = new FileType(3, "hex", true);
    }
