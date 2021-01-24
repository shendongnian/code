    void Main() {
        var test = new MyClass();
        test.Settings = settingModule.fileTypeA;
        Console.WriteLine(test.Settings.startingRow);
    }
    
    public class MyClass {
        public settingModule.settingsSet Settings { get; set; }
    
    }
    
    public static class settingModule {
        public class settingsSet {
            public readonly int startingRow;
            public readonly string fileType;
            public readonly bool skipEmpty;
            public settingsSet(int sr, string ft, bool se) {
                startingRow = sr;
                fileType = ft;
                skipEmpty = se;
            }
        }
    
        public static settingsSet fileTypeA = new settingsSet(1, "txt", true);
        public static settingsSet fileTypeB = new settingsSet(10, "csv", false);
        public static settingsSet fileTypeC = new settingsSet(3, "hex", true);
    }
