    public class NullLogWriter : LogWriter
    {
        /// <inheritdoc />
        public NullLogWriter(LoggingConfiguration config) : base(config)
        {
        }
        /// <inheritdoc />
        public NullLogWriter(IEnumerable<ILogFilter> filters, IDictionary<string, LogSource> traceSources, LogSource errorsTraceSource, string defaultCategory) : base(filters, traceSources, errorsTraceSource, defaultCategory)
        {
        }
        /// <inheritdoc />
        public NullLogWriter(IEnumerable<ILogFilter> filters, IDictionary<string, LogSource> traceSources, LogSource allEventsTraceSource, LogSource notProcessedTraceSource, LogSource errorsTraceSource, string defaultCategory, bool tracingEnabled, bool logWarningsWhenNoCategoriesMatch) : base(filters, traceSources, allEventsTraceSource, notProcessedTraceSource, errorsTraceSource, defaultCategory, tracingEnabled, logWarningsWhenNoCategoriesMatch)
        {
        }
        /// <inheritdoc />
        public NullLogWriter(IEnumerable<ILogFilter> filters, IDictionary<string, LogSource> traceSources, LogSource allEventsTraceSource, LogSource notProcessedTraceSource, LogSource errorsTraceSource, string defaultCategory, bool tracingEnabled, bool logWarningsWhenNoCategoriesMatch, bool revertImpersonation) : base(filters, traceSources, allEventsTraceSource, notProcessedTraceSource, errorsTraceSource, defaultCategory, tracingEnabled, logWarningsWhenNoCategoriesMatch, revertImpersonation)
        {
        }
        /// <inheritdoc />
        public NullLogWriter(IEnumerable<ILogFilter> filters, IEnumerable<LogSource> traceSources, LogSource errorsTraceSource, string defaultCategory) : base(filters, traceSources, errorsTraceSource, defaultCategory)
        {
        }
        /// <inheritdoc />
        public NullLogWriter(IEnumerable<ILogFilter> filters, IEnumerable<LogSource> traceSources, LogSource allEventsTraceSource, LogSource notProcessedTraceSource, LogSource errorsTraceSource, string defaultCategory, bool tracingEnabled, bool logWarningsWhenNoCategoriesMatch) : base(filters, traceSources, allEventsTraceSource, notProcessedTraceSource, errorsTraceSource, defaultCategory, tracingEnabled, logWarningsWhenNoCategoriesMatch)
        {
        }
        /// <inheritdoc />
        public NullLogWriter(LogWriterStructureHolder structureHolder) : base(structureHolder)
        {
        }
    }
    class Program
    {
        private static readonly LogWriter NullLogWriter = new NullLogWriter(new LoggingConfiguration());
        static void Main(string[] args)
        {
            Log("Test 1", "General");            
            Log("Test 2", "General");            
        }
        static void Log(string message, string category)
        {
            if (HasLogWriterBeenDisposed())
            {
                InitializeLogger();
            }
            // Write message
            Logger.Write(message, category);
            // Set the logger to the null logger this disposes the current LogWriter
            // Note that this call is not thread safe so would need to be synchronized in multi-threaded environment
            Logger.SetLogWriter(NullLogWriter, false);
        }
        static bool HasLogWriterBeenDisposed()
        {
            try
            {
                // If logger is the NullLogWriter then it needs to be set
                return Logger.Writer is NullLogWriter;
            }
            catch (InvalidOperationException e)
            {
                // If InvalidOperationException is thrown then logger is not set -- consider this to be disposed
                return true;
            }
        }
        static void InitializeLogger()
        {
            IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
            LogWriterFactory logWriterFactory = new LogWriterFactory(configurationSource);
            Logger.SetLogWriter(logWriterFactory.Create(), false);            
        }
    }
