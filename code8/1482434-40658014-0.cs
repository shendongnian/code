    public class MasterEmailSettings
    {
        private static MasterEmailSettings _settings;
        public string User { get; }
        public string Domain { get; }
        public string Password { get; }
        public string EmailAddress { get; }
        private MasterEmailSettings()
        {
            this.User = "user";
            this.Password = "pw";
            this.Domain = "domain";
            this.EmailAddress = "foo@bar.com";
        }
        public static MasterEmailSettings Load(string path)
        {
            if (!File.Exists(path))
            {
                _settings = new MasterEmailSettings();
                Save(path);
                return _settings;
            }
            var json = File.ReadAllText(path);
            _settings = JsonConvert.DeserializeObject<MasterEmailSettings>(File.ReadAllText(path));
            return _settings;
        }
        private static void Save(string path)
        {
            var json = JsonConvert.SerializeObject(_settings, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
