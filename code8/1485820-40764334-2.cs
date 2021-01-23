    public class PerformanceInstanceProviderBehaviorAttribute : Attribute, IServiceBehavior
    {
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription,
                ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher cd in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher ed in cd.Endpoints)
                {
                    if (!ed.IsSystemEndpoint)
                    {
                        //Each Service Type is getting their own InstanceProvider,
                        //So we can pass the type along,
                        //and let a factory create the appropriate instances:
                        ed.DispatchRuntime.InstanceProvider =
                            new ServiceInstanceProvider(serviceDescription.ServiceType);
                    }
                }
            }
        }
        ...
    }
