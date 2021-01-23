    public abstract class PerformanceMonitoredService
    {
        public abstract PerformanceContext PerformanceContext { get; protected set; }
        public PerformanceMonitoredService() {}
        public PerformanceMonitoredService(PerformanceContext perfContext) {}
    }
