    [ServiceBehavior(Name = "MyStickyServicee",
        InstanceContextMode = InstanceContextMode.PerSession,
        ConcurrencyMode = ConcurrencyMode.Single)]
    
    public class MyStickyService : IMyStickyService, IDisposable
    {
    }
