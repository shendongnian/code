    // Defined in application
    public interface IForestFactory
    {
        IForest Create();
    }
    
    // Defined inside the Composition Root
    public class ForestFactory : IForestFactory
    {
        private readonly Container container;
        
        public ForestFactory(Container container) {
            this.container = container;
        }
        
        public IForest Create() {
            return this.container.GetInstance<IForest>();
        }
    }
    
    // Inside the Bootstrapper
    var factory = new ForestFactory(Container);
    Container.Register<IForestFactory>(() => factory);
