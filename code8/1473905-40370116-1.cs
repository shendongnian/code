    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition;
    
    class Program
    {
        static void Main(string[] args)
        {
            var bootstrap = new Bootstrap();
            var service = bootstrap.Container.GetExportedValue<IService>();
            service.DoServiceWork();
        }
    
            
    }
    
    public class Bootstrap
    {
        [Export]
        public CompositionContainer Container { get; private set; }
    
        [Export(typeof(ILogger))]
        public ILogger Logger { get; private set; }
    
        public  Bootstrap()
        {
            //Create an aggregate catalog that will hold assembly references
            var catalog = new AggregateCatalog();
    
            //Adds this assembly. 
            //Exports defined in the classes and types within this assembly will now be composable
            //Add to the catalogs if there are more assemblies where exports are defined.
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
    
            //Create the CompositionContainer with the parts in the catalog
            this.Container = new CompositionContainer(catalog);
    
            this.Logger = Logger.GetLogger(LoggerType.MongoLogger);
            this.Container.ComposeParts(this);
        }
    }
    
    [Export(typeof(IService))]
    public class MyService : IService
    {
    
        //adding pragma directive removes compiler warning of unassigned property/field
        //as these will be assigned by MEF import 
    #pragma warning disable
    
        [Import]
        private ILogger _logger;
    
    #pragma warning restore
    
    
        public MyService()
        {
            //logger will be instantiated by MEF
        }
    
        public void DoServiceWork()
        {
            _logger.Log("Starting service work");
        }
    }
