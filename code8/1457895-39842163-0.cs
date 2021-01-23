    namespace TestSO39836570TraceListenerBindingErrors
    {
        class EnvironmentAwareTextWriterTraceListener : TextWriterTraceListener
        {
            public EnvironmentAwareTextWriterTraceListener(string path)
                : base(Environment.ExpandEnvironmentVariables(path))
            { }
    
            public EnvironmentAwareTextWriterTraceListener(string path, string name)
                : base(Environment.ExpandEnvironmentVariables(path), name)
            { }
        }
    }
