    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class TheService : IService, IDisposable
    {
        ...
        public void Dispose()
        {
            // code of session termination
            ...
        }
    }
