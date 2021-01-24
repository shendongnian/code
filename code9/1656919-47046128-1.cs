    static class LoggerSinkConfigurationExtensions
    {
        public static LoggerConfiguration Boosted(
            this LoggerSinkConfiguration lsc,
            Action<LoggerSinkConfiguration> writeTo)
        {
            return LoggerSinkConfiguration.Wrap(
                lsc,
                wrapped => new LevelBoostingWrapper(wrapped),
                writeTo);
        }
    }
