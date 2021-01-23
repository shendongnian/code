    [ServiceContract]
    public interface IJobsService { ... }
    [PerformanceInstanceProviderBehavior]
    public partial class JobsService : PerformanceMonitoredService, IJobsService
    {
        public PerformanceContext PerformanceContext { get; protected set; }
        JobsService() { ... }
        JobsService(PerformanceContext perfContext) : this()
        {
            PerformanceContext = perfContext;
        }
        ...
    }
