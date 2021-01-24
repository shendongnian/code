    internal class ConfigManager<T>
    {
        private string _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("{0}.xml", AppDomain.CurrentDomain.FriendlyName));
        private T _config;
        private XmlSerializer serializer = new XmlSerializer(typeof(T));
        public T MyConfig
        {
            get { return _config; }
            set { _config = value; }
        }
        public void LoadConfig()
        {
            if (File.Exists(_fileName))
            {
                using (var reader = File.OpenText(_fileName))
                {
                    _config = (T)serializer.Deserialize(reader);
                }
            }
        }
        public void SaveConfig()
        {
            using (var writer = File.CreateText(_fileName))
            {
                serializer.Serialize(writer, _config);
            }
        }
    }
