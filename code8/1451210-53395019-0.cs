    using System;
    
    namespace MyApplication.Infrastructure.Logging.LoggingAbstractBase
    {
        public interface ILogger
        {
            void Log(LogEntry entry);
            void Log(string message);
            void Log(Exception exception);
        }
    }
    
    
    namespace MyApplication.Infrastructure.Logging.LoggingAbstractBase
    {
        public enum LoggingEventTypeEnum
        {
            Debug,
            Information,
            Warning,
            Error,
            Fatal
        };
    }
    
    
    
    using System;
    
    namespace MyApplication.Infrastructure.Logging.LoggingAbstractBase
    {
        public class LogEntry
        {
            public readonly LoggingEventTypeEnum Severity;
            public readonly string Message;
            public readonly Exception Exception;
    
            public LogEntry(LoggingEventTypeEnum severity, string message, Exception exception = null)
            {
                if (message == null) throw new ArgumentNullException("message");
                if (message == string.Empty) throw new ArgumentException("empty", "message");
    
                this.Severity = severity;
                this.Message = message;
                this.Exception = exception;
            }
        }
    }
    
    
    
    using System;
    using Microsoft.Extensions.Logging;
    
    namespace MyApplication.Infrastructure.Logging.LoggingCoreConcrete
    {
        public class DotNetCoreLogger<T> : MyApplication.Infrastructure.Logging.LoggingAbstractBase.ILogger
        {
            private readonly ILogger<T> concreteLogger;
    
            public DotNetCoreLogger(Microsoft.Extensions.Logging.ILogger<T> concreteLgr)
            {
                this.concreteLogger = concreteLgr ?? throw new ArgumentNullException("Microsoft.Extensions.Logging.ILogger is null");
            }
    
            public void Log(MyApplication.Infrastructure.Logging.LoggingAbstractBase.LogEntry entry)
            {
                if (null == entry)
                {
                    throw new ArgumentNullException("LogEntry is null");
                }
                else
                {
                    switch (entry.Severity)
                    {
                        case LoggingAbstractBase.LoggingEventTypeEnum.Debug:
                            this.concreteLogger.LogDebug(entry.Message);
                            break;
                        case LoggingAbstractBase.LoggingEventTypeEnum.Information:
                            this.concreteLogger.LogInformation(entry.Message);
                            break;
                        case LoggingAbstractBase.LoggingEventTypeEnum.Warning:
                            this.concreteLogger.LogWarning(entry.Message);
                            break;
                        case LoggingAbstractBase.LoggingEventTypeEnum.Error:
                            this.concreteLogger.LogError(entry.Message, entry.Exception);
                            break;
                        case LoggingAbstractBase.LoggingEventTypeEnum.Fatal:
                            this.concreteLogger.LogCritical(entry.Message, entry.Exception);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(string.Format("LogEntry.Severity out of range. (Severity='{0}')", entry.Severity));
                    }
                }
            }
    
            public void Log(string message)
            {
                this.concreteLogger.LogInformation(message);
            }
    
            public void Log(Exception exception)
            {
                this.concreteLogger.LogError(exception.Message, exception);
            }
        }
    }
    
    
    
    /* IoC/DI below */
    
    
            private static System.IServiceProvider BuildDi(Microsoft.Extensions.Configuration.IConfiguration config)
            {
                //setup our DI
                IServiceProvider serviceProvider = new ServiceCollection()
                    .AddLogging()
                    .AddSingleton<IConfiguration>(config)
                    .AddSingleton<MyApplication.Infrastructure.Logging.LoggingAbstractBase.ILogger, MyApplication.Infrastructure.Logging.LoggingCoreConcrete.DotNetCoreLogger<Program>>()
                    .BuildServiceProvider();
    
                //configure console logging
                serviceProvider
                    .GetService<ILoggerFactory>()
                    .AddConsole(LogLevel.Debug);
    
                return serviceProvider;
            }
