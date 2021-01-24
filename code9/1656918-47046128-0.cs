    class LevelBoostingWrapper : ILogEventSink, IDisposable
    {
        readonly ILogEventSink _wrappedSink;
        public LevelBoostingWrapper(ILogEventSink wrappedSink)
        {
            _wrappedSink = wrappedSink;
        }
        public void Emit(LogEvent logEvent)
        {
            if (logEvent.Level == LogEventLevel.Warning)
            {
                var boosted = new LogEvent(
                    logEvent.Timestamp,
                    LogEventLevel.Warning, // <- the boost
                    logEvent.Exception,
                    logEvent.MessageTemplate,
                    logEvent.Properties
                        .Select(kvp => new LogEventProperty(kvp.Key, kvp.Value)));
                _wrappedSink.Emit(boosted);
            }
            else
            {
                _wrappedSink.Emit(logEvent);
            }
        }
        public void Dispose()
        {
            (_wrappedSink as IDisposable)?.Dispose();
        }
    }
