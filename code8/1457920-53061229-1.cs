    public class PackageSettings
    {
        public static readonly PackageSettings Active;
        public static readonly PackSettingReader SettingReader = new PackSettingReader("Packaging");
        static PackageSettings()
        {
            Active = new PackageSettings
            {
                UserId = SettingReader.Get("UserId", 1),
            };
        }
        public long? UserId { get;  set; }
    }
