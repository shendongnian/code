    public class ConsulService : IDisposable
    {
        public ConsulService(IOptions<ConsulOptions> optAccessor) { }
        public void Register() 
        {
            //possible implementation of synchronous API
            client.Agent.ServiceRegister(registration).GetAwaiter().GetResult();
        }
    }
