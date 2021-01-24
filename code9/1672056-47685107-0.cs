    public class Setting
    {
        public Setting(int startingRow, string fileType, bool skipEmpty)
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
        public static Setting FileTypeA { get; } = new Setting(1, "txt", true);
        public static Setting FileTypeB { get; } = new Setting(10, "csv", false);
        public static Setting FileTypeC { get; } = new Setting(3, "hex", true);
    }
