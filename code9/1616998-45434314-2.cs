    public interface IServiceOneFactory
    {
        IServiceOne Create(CountryCode countryCode);
    }
    
    public class ServiceOne : IServiceOne
    {
        public ServiceOne(IServiceTwo servicetwo, CountryCode countryCode)
        {
        }
    }
    
    public class ActorExample
    {
        private raedonly IServiceOneFactory factory;
        public ActorExample(IServiceOneFactory factory)
        {
            this.factory = factory;
        }
        public async Task ProcessAsync(Event event)
        {
            var serviceOne = this.factory.Create(event.CountryCode);
        }
    }
