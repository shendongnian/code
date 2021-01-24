    public static class settingModule {
        public struct settingsSet {
            public int startingRow;
            public string fileType;
            public bool skipEmpty;
        }
    
        public static readonly settingsSet fileTypeA = new settingsSet {
            startingRow = 1,
            fileType = "txt",
            skipEmpty = true
        };
    
        public static readonly settingsSet fileTypeB = new settingsSet {
            startingRow = 10,
            fileType = "csv",
            skipEmpty = false
        };
    
        public static readonly settingsSet fileTypeC = new settingsSet {
            startingRow = 3,
            fileType = "hex",
            skipEmpty = true
        };
    }
