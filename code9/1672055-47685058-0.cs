    public sealed class SettingMobule
    {
        public int StartingRow {get; private set;}
        public string FileType {get; private set;}
        public bool SkipEmpty {get; private set;}
        private SettingMobule(int startingRow, string fileType, bool skipEmpty)
        {
            StartingRow = startingRow;
            FileType = fileType;
            SkipEmpty = skipEmpty;
        }
        public static SettingMobule FileTypeA {get;}
              = new SettingMobule(1, "txt", true);
        public static SettingMobule FileTypeB {get;}
              = new SettingMobule(10, "csv", false);
        public static SettingMobule FileTypeC {get;}
              = new SettingMobule(3, "hex", true);
    }
