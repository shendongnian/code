    class Settings
    {
        static Settings()
        {
            LoadDefault();
        }
        public static void LoadDefault()
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
