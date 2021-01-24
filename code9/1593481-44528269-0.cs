        /// <summary>
        /// Creates the custom log file.
        /// Logging of Info and Warning Message Only.
        /// </summary>
        /// <param name="TargetName">Name of the target.</param>
        /// <param name="TargetFileName">Name of the target file.</param>
        /// <param name="LoggerName">Name of the logger.</param>
        public void CreateCustomLogFile(String TargetName, String TargetFileName, String LoggerName = "*")
        {
            try
            {
                var NLogTarget = LogManager.Configuration.FindTargetByName(TargetName);
                if (NLogTarget == null) //Don't Re Add the Target
                {
                    NLogTarget = new FileTarget()
                    {
                        Name = TargetName,
                        FileName = TargetFileName,
                        Layout = @"[${date:format=yyyy-MM-dd HH\:mm\:ss}] ${message}"
                    };
                    LogManager.Configuration.AddTarget(TargetName, NLogTarget);
                }
                var NLogRule = new LoggingRule(LoggerName, NLogTarget);
                NLogRule.EnableLoggingForLevel(LogLevel.Info);
                NLogRule.EnableLoggingForLevel(LogLevel.Warn);
                LogManager.Configuration.LoggingRules.Add(NLogRule);
                LogManager.ReconfigExistingLoggers();
            }
            catch { }
        }
        /// <summary>
        /// Removes the custom log file.
        /// </summary>
        /// <param name="TargetName">Name of the target.</param>
        public void RemoveCustomLogFile(String TargetName)
        {
            try
            {
                if (LogManager.Configuration.FindTargetByName(TargetName) != null)
                {
                    var Target = LogManager.Configuration.FindTargetByName(TargetName);
                    foreach (var rule in LogManager.Configuration.LoggingRules)
                    {
                        rule.Targets.Remove(Target);
                    }
                    LogManager.Configuration.RemoveTarget(TargetName);
                    Target.Dispose();
                    LogManager.ReconfigExistingLoggers();
                }
            }
            catch { }
        }
    
