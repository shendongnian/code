    public class MyAppSettingsBridge : IAppSettings
    {
        private readonly IOptions<MyAppSettings> _appSettings;
        private readonly ISettingsDecrypt _decryptor;
        public MyAppSettingsBridge(IOptionsSnapshot<MyAppSettings> appSettings, ISettingsDecrypt decryptor) {
            _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            _decryptor = decryptor ?? throw new ArgumentException(nameof(decryptor));
        }
        public string ApplicationName => _appSettings.Value.ApplicationName;
        public string SqlConnectionSting => _decryptor.Decrypt(_appSettings.Value.Sql);
        public string OracleConnectionSting => _decryptor.Decrypt(_appSettings.Value.Oracle);
    }
