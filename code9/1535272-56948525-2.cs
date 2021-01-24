    public static class Logger
    {
        private static ILog _log;
        private static LOGGING_MODE _logMode = LOGGING_MODE.CONSOLE_AND_FILE;
    
        public static LOGGING_MODE LogMode { get => _logMode; set => _logMode = value; }
    
        private static void EnsureLogger()
        {
            if (_log != null)
                return;
    
            var assembly = Assembly.GetEntryAssembly();
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            var configFile = GetConfigFile();
    
            // Configure Log4Net
            XmlConfigurator.Configure(logRepository, configFile);
            _log = LogManager.GetLogger(assembly, assembly.ManifestModule.Name.Replace(".dll", "").Replace(".", " "));
        }
    
        private static FileInfo GetConfigFile()
        {
            FileInfo configFile = null;
            // Search config file
            var configFileNames = new[] { "Config/log4net.config", "log4net.config" };
            foreach (var configFileName in configFileNames)
            {
                configFile = new FileInfo(configFileName);
                if (configFile.Exists) break;
            }
            if (configFile == null || !configFile.Exists) throw new NullReferenceException("Log4net config file not found.");
            return configFile;
        }
    
        public static void LogDebug(string message)
        {
            EnsureLogger();
            if (_logMode == LOGGING_MODE.FILE || _logMode == LOGGING_MODE.CONSOLE_AND_FILE)
                _log.Debug($"{message}");
            if (_logMode == LOGGING_MODE.CONSOLE || _logMode == LOGGING_MODE.CONSOLE_AND_FILE)
                Console.WriteLine($"{message}");
        }
        public static void LogInfo(string message)
        {
            EnsureLogger();
            if (_logMode == LOGGING_MODE.FILE || _logMode == LOGGING_MODE.CONSOLE_AND_FILE)
                _log.Info($"{message}");
            if (_logMode == LOGGING_MODE.CONSOLE || _logMode == LOGGING_MODE.CONSOLE_AND_FILE)
                Console.WriteLine($"{message}");
        }
        public static void LogWarn(string message)
        {
            EnsureLogger();
            if (_logMode == LOGGING_MODE.FILE || _logMode == LOGGING_MODE.CONSOLE_AND_FILE)
                _log.Warn($"{message}");
            if (_logMode == LOGGING_MODE.CONSOLE || _logMode == LOGGING_MODE.CONSOLE_AND_FILE)
                Console.WriteLine($"{message}");
        }
        public static void LogError(string message)
        {
            EnsureLogger();
            if (_logMode == LOGGING_MODE.FILE || _logMode == LOGGING_MODE.CONSOLE_AND_FILE)
                _log.Error($"{message}");
            if (_logMode == LOGGING_MODE.CONSOLE || _logMode == LOGGING_MODE.CONSOLE_AND_FILE)
                Console.WriteLine($"{message}");
        }
    }
