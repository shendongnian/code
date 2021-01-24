    // MUST BE PUBLIC 
    public static IContainer Container{ get; set; }
     
    static App()  
    {
       InitializeIOCContainer();  
    } 
     
    public App () 
    {    
       InitializeComponent(); 
    }
    private static void InitializeIOCContainer() 
    {    
       var builder = new ContainerBuilder();    
       builder.RegisterType<MessagingCenterWrapper>().As<IMessagingCenterWrapper>();
       Container = builder.Build();
     
       // Don't stick view models in the container unless you need them globally, which is almost never true !!!
       // Don't Resolve the service variable until you need it !!!! }
    }  
  
