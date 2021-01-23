       public sealed class Logger : ILogger
        {
            private readonly Serilog.ILogger _seriLogger;
    
            public Logger(Serilog.ILogger seriLogger)
            {
                _seriLogger = seriLogger;
            }
    
            public void Debug(string format, params object[] args)
            {
                _seriLogger.Debug(format, args);
            }
    
            public void Info(string format, params object[] args)
            {
                _seriLogger.Information(format, args);
            }
    
            public void Warn(string format, params object[] args)
            {
                _seriLogger.Warning(format, args);
            }
    
            public void Error(Exception e, string format, params object[] args)
            {
                _seriLogger.Error(e, format, args);
            }
    
            public void Fatal(Exception e, string format, params object[] args)
            {
                _seriLogger.Fatal(e, format, args);
            }
    
            public IDisposable GetScope(string name, long timeout = 0)
            {
                return new LoggerScope(this, name, timeout);
            }
        }
    
        internal class LoggerScope : IDisposable
        {
            private readonly ILogger _logger;
    
            private readonly string _name;
    
            private readonly long _timeout;
    
            private readonly Stopwatch _sw;
    
            private bool ExceedScope
            {
                get { return _timeout > 0; }
            }
    
            public LoggerScope(ILogger logger, string name, long timeout)
            {
                _logger = logger;
                _name = name;
                _timeout = timeout;
    
                if (!ExceedScope)
                {
                    _logger.Debug("Start execution of {0}.", name);
                }
                _sw = Stopwatch.StartNew();
            }
    
            public void Dispose()
            {
                _sw.Stop();
    
                if (ExceedScope)
                {
                    if (_sw.ElapsedMilliseconds >= (long)_timeout)
                    {
                        _logger.Debug("Exceeded execution of {0}. Expected: {1}ms; Actual: {2}ms.", _name, _timeout.ToString("N"), _sw.Elapsed.TotalMilliseconds.ToString("N"));
                    }
                }
                else
                {
                    _logger.Debug("Finish execution of {0}. Elapsed: {1}ms", _name, _sw.Elapsed.TotalMilliseconds.ToString("N"));
                }
            }
        }
