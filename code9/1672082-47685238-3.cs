    public static class settingModule {
        public struct settingsSet {
            public int startingRow;
            public string fileType;
            public bool skipEmpty;
        }
    
        public static settingsSet fileTypeA = new settingsSet {
            startingRow = 1,
            fileType = "txt",
            skipEmpty = true
        };
    
        public static settingsSet fileTypeB = new settingsSet {
            startingRow = 10,
            fileType = "csv",
            skipEmpty = false
        };
    
        public static settingsSet fileTypeC = new settingsSet {
            startingRow = 3,
            fileType = "hex",
            skipEmpty = true
        };
    }
