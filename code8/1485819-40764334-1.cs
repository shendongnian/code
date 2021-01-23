    public class ServiceInstanceProvider : IInstanceProvider
    {
        public Type ServiceType { get; set; }
        public ServiceInstanceProvider(Type serviceType) { ServiceType = serviceType; }
        public object GetInstance(InstanceContext instanceContext)
        {
            return this.GetInstance(instanceContext, null);
        }
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            var perfContext = new PerformanceInstanceContext();
            instanceContext.Extensions.Add(new PerformanceInstanceExtension(perfContext));
            return ServiceFactory.Create(ServiceType, perfContext);
            //return new JobsService(perfContext);
        }
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            var perfContext = (instanceContext.Extensions.FirstOrDefault(ice =>
                              ice is PerformanceInstanceExtension)
                              as PerformanceInstanceExtension
                              )?.PerformanceContext;
            //Handle the object which has been through the pipeline
            //Note (IErrorHandler):
            //This is called after "ProvideFault", but before "HandleError"
        }
    }
