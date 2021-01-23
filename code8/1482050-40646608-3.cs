    public static class LoggerExtensionsHelper
    {
        public const string Debug = "DEBUG";
        public const string Trace = "TRACE";
    
        /// <summary>Formats and writes a debug log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        [Conditional(Debug)]
        public static void LogDebug(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            LoggerExtensions.LogDebug(logger, eventId, exception, message, args);
        }
    
        /// <summary>Formats and writes a debug log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        [Conditional(Debug)]
        public static void LogDebug(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            LoggerExtensions.LogDebug(logger, eventId, message, args);
        }
    
        /// <summary>Formats and writes a debug log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        [Conditional(Debug)]
        public static void LogDebug(this ILogger logger, string message, params object[] args)
        {
            LoggerExtensions.LogDebug(logger, message, args);
        }
    
        /// <summary>Formats and writes a trace log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        [Conditional(Trace)]
        public static void LogTrace(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            LoggerExtensions.LogTrace(logger, eventId, exception, message, args);
        }
    
        /// <summary>Formats and writes a trace log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        [Conditional(Trace)]
        public static void LogTrace(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            LoggerExtensions.LogTrace(logger, eventId, message, args);
        }
    
        /// <summary>Formats and writes a trace log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        [Conditional(Trace)]
        public static void LogTrace(this ILogger logger, string message, params object[] args)
        {
            LoggerExtensions.LogTrace(logger, message, args);
        }
    
    
        /// <summary>Formats and writes an informational log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void LogInformation(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            LoggerExtensions.LogInformation(logger, eventId, exception, message, args);
        }
    
        /// <summary>Formats and writes an informational log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void LogInformation(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            LoggerExtensions.LogInformation(logger, eventId, message, args);
        }
    
        /// <summary>Formats and writes an informational log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void LogInformation(this ILogger logger, string message, params object[] args)
        {
            LoggerExtensions.LogInformation(logger, message, args);
        }
    
        /// <summary>Formats and writes a warning log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void LogWarning(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            LoggerExtensions.LogWarning(logger, eventId, exception, message, args);
        }
    
        /// <summary>Formats and writes a warning log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void LogWarning(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            LoggerExtensions.LogWarning(logger, eventId, message, args);
        }
    
        /// <summary>Formats and writes a warning log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void LogWarning(this ILogger logger, string message, params object[] args)
        {
            LoggerExtensions.LogWarning(logger, message, args);
        }
    
        /// <summary>Formats and writes an error log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void LogError(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            LoggerExtensions.LogError(logger, eventId, exception, message, args);
        }
    
        /// <summary>Formats and writes an error log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void LogError(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            LoggerExtensions.LogError(logger, eventId, message, args);
        }
    
        /// <summary>Formats and writes an error log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void LogError(this ILogger logger, string message, params object[] args)
        {
            LoggerExtensions.LogError(logger, message, args);
        }
    
        /// <summary>Formats and writes a critical log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void LogCritical(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
        {
            LoggerExtensions.LogCritical(logger, eventId, exception, message, args);
        }
    
        /// <summary>Formats and writes a critical log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void LogCritical(this ILogger logger, EventId eventId, string message, params object[] args)
        {
            LoggerExtensions.LogCritical(logger, eventId, message, args);
        }
    
        /// <summary>Formats and writes a critical log message.</summary>
        /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void LogCritical(this ILogger logger, string message, params object[] args)
        {
            LoggerExtensions.LogCritical(logger, message, args);
        }
    }
