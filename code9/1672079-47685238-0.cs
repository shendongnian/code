    void Main() {
        var test = new MyClass(typeof(settingModule.fileTypeB));
        Console.WriteLine(test.StartingRow);
    }
    
    public class MyClass {
        Type SettingsClass { get; set; }
    
        public MyClass(Type sc) {
            SettingsClass = sc;
        }
        
        public int StartingRow {
            get {
                return (int)SettingsClass.GetField("startingRow", BindingFlags.Static | BindingFlags.Public).GetValue(null);
            }
        }
    }
    
    public static class settingModule {
        public static class fileTypeA {
            public static int startingRow = 1;
            public static String fileType = "txt";
            public static bool skipEmpty = true;
        }
    
        public static class fileTypeB {
            public static int startingRow = 10;
            public static String fileType = "csv";
            public static bool skipEmpty = false;
        }
    
        public static class fileTypeC {
            public static int startingRow = 3;
            public static String fileType = "hex";
            public static bool skipEmpty = true;
        }
    
    }
