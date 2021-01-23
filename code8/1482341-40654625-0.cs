    public class BasicFactory : IBasicFactory {
        private readonly Dictionary<string, InstanceProducer> producers =
            new Dictionary<string, InstanceProducer>(StringComparer.OrdinalIgnoreCase);
        private readonly Container container;
        public BasicFactory(Container container) {
            this.container = container;
        }
        Basic IBasicFactory.CreateNew(string name) => (Basic)this.producers[name].GetInstance();
        public void Register<TImplementation>(string name, Lifestyle lifestyle = null)
            where TImplementation : class, Basic {
            lifestyle = lifestyle ?? Lifestyle.Transient;
            var producer = lifestyle.CreateProducer<Basic, TImplementation>(container);
            this.producers.Add(name, producer);
        }
    }
	
