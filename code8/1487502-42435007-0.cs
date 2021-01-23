    sealed class ConfigurationGenerator : IDisposable
    {
        private string _tempFileName;
        public ConfigurationGenerator(string configurationData)
        {
            if (String.IsNullOrEmpty(configurationData)) throw new ArgumentNullException("configurationData");
            _tempFileName = Path.GetTempFileName();
            File.WriteAllText(_tempFileName, configurationData);
        }
        public System.Configuration.Configuration Generate()
        {
            var filemap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = _tempFileName
            };
            var config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(filemap, ConfigurationUserLevel.None);
            return config;
        }
        public void Dispose()
        {
            if (_tempFileName != null)
            {
                string s = _tempFileName;
                _tempFileName = null;
                File.Delete(s);
            }
        }
    }
