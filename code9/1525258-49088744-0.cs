    public class DependencyJobActivator : JobActivator
    {
        private readonly IServiceProvider _serviceProvider;
        public DependencyJobActivator(IServiceProvider serviceProvider)
		{ 
			_serviceProvider = serviceProvider;
		}
        public override object ActivateJob(Type jobType) {
			return _serviceProvider.GetService(jobType);
		}
    }
