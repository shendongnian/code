        public class Logger : ILogger
        {
            Func<IAppSettingsProvider> appSettingsProviderFactory;
            IAppSettingsProvider _appSettingsProvider;
            IAppSettingsProvider appSettingsProvider { get
                {
                    if (_appSettingsProvider == null) _appSettingsProvider = appSettingsProviderFactory();
                    return _appSettingsProvider;
                }
            }
            public Logger(Func<IAppSettingsProvider> appSettingsProviderFactory)
            {
                this.appSettingsProviderFactory = appSettingsProviderFactory;
            }
            public void Log(string message)
            {
                // simplified
                if (this.appSettingsProvider.GetSettings())
                {
                    Console.WriteLine(message);
                }
            }
        }
