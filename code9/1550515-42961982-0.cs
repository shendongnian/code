    public static class AppConfig {
        static AppConfig() {
            Log = new LogSettings(1);
        }
        public class LogSettings {
            public LogSettings(int fileSize) {
                FileSize = fileSize;
            }
            public int FileSize { get; private set; }
        }
        public static LogSettings Log { get; private set; }
    }
