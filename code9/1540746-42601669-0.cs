    class Settings
    {
        static Settings()
        {
            Reset()
        }
        public static void Reset()
        {
            SaveDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Type = ImageFormat.Png;
        }
        public static string SaveDir
        {
            get;
            set;
        }
        public static ImageFormat Type
        {
            get;
            set;
        }
    }
