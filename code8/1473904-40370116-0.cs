    public class SomeInitClass
    {
      [Export]
      public CompositionContainer Container {get; set;}
    
      [Export]
      public ILogger Logger {get; set; }
    
      public SomeInitClass()
      {
        this.Logger = Logger.GetLogger(LoggerType.MongoLogger);
        this.Container = new CompositionContainer();
        this.Container.ComposeParts(this);
      }
    }
    
    [Export(typeof(IService))]
        public class MyService: IService
        {
            [Import]
            private ILogger _logger;    
    
            public Property()
            {
              //logger will be instantiated by MEF
            }
    
            public void DoServiceWork()
            {
                _logger.Log("Starting service work");
            }
        }         
    }
