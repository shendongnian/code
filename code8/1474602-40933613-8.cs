    namespace LoggingTestConsole
    {
        using System;
    
        /// <summary>
        /// Generic logging interface for portability 
        /// </summary>
        public interface ILogger
        {
            void Error(string message);
            void Information(string message);
            void Warning(string message);
        }
    
    
        /// <summary>
        /// Azure Functions logger
        /// </summary>
        public class AzureFunctionLogger : ILogger
        {
            private static Microsoft.Azure.WebJobs.Host.TraceWriter _logger;
    
            public AzureFunctionLogger(Microsoft.Azure.WebJobs.Host.TraceWriter logger)
            {
                _logger = logger;
            }
    
            public void Error(string message)
            {
                _logger.Error(message);
            }
    
            public void Information(string message)
            {
                _logger.Info(message);
            }
    
            public void Warning(string message)
            {
                _logger.Warning(message);
            }
        }
    
    
        /// <summary>
        /// Windows Trace logger
        /// </summary>
        public class TraceLogger : ILogger
        {
            public TraceLogger()
            {
                System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.TextWriterTraceListener(Console.Out));
            }
    
            public void Error(string message)
            {
                System.Diagnostics.Trace.TraceError(message);
            }
    
    
            public void Information(string message)
            {
                System.Diagnostics.Trace.TraceInformation(message);
            }
    
            public void Warning(string message)
            {
                System.Diagnostics.Trace.TraceWarning(message);
            }
    
            public void Warning(string format, params object[] args)
            {
                System.Diagnostics.Trace.TraceWarning(format, args);
            }
        }
    
        /// <summary>
        /// You would put this in a separate project and just share the ILogger interface.
        /// Pass the relevant logger in from Azure Functions or a standard windows Trace logger.
        /// </summary>
        public class DoStuff
        {
            public DoStuff(ILogger logger)
            {
                logger.Information("We are logging to logger you passed in!");
            }
        }
    
        public class Program
        {
    
            /// <summary>
            /// Sample usage
            /// </summary>
            static void Main(string[] args)
            {
                // var loggerEnvironment = "AzureFunctions";
                var loggerEnvironment = "ConsoleApp";
    
                ILogger logger = null;
    
                if (loggerEnvironment == "AzureFunctions")
                {
                    Microsoft.Azure.WebJobs.Host.TraceWriter azureFunctionLogger = null;
                    logger = new AzureFunctionLogger(azureFunctionLogger);
                }
                else if (loggerEnvironment == "ConsoleApp")
                {
                    logger = new TraceLogger();
                }
    
                var doStuff = new DoStuff(logger);
                Console.ReadKey();
            }
        }
    }
