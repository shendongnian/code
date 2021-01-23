    public class PerformanceInstanceExtension : IExtension<InstanceContext>
    {
        public PerformanceInstanceExtension()
        {
            PerformanceContext = new PerformanceContext();
        }
        public PerformanceInstanceExtension(PerformanceContext perfContext)
        {
            PerformanceContext = perfContext;
        }
        public PerformanceContext PerformanceContext { get; private set; }
        public void Attach(InstanceContext owner) {}
        public void Detach(InstanceContext owner) {}
    }
