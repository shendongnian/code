    public class SerilogAdapter : ILogger
    {
        private readonly Serilog.ILogger m_Adaptee;
        public SerilogAdapter(Serilog.ILogger adaptee)
        {
            m_Adaptee = adaptee;
        }
        public void Log(LogEntry entry)
        {
            if (entry.Severity == LoggingEventType.Debug)
                m_Adaptee.Debug(entry.Exception, entry.Message);
            if (entry.Severity == LoggingEventType.Information)
                m_Adaptee.Information(entry.Exception, entry.Message);
            else if (entry.Severity == LoggingEventType.Warning)
                m_Adaptee.Warning(entry.Message, entry.Exception);
            else if (entry.Severity == LoggingEventType.Error)
                m_Adaptee.Error(entry.Message, entry.Exception);
            else
                m_Adaptee.Fatal(entry.Message, entry.Exception);
        }
    }
