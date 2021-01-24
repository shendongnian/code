    private readonly IoCContainer _container = null;
    
    private IMyService _myService = null;
    public IMyService MyService
    {
       get { return _myService ?? (_myService = _container.Resolve<IMyService>()); }
       set { _myService = value; }
    }
    
    public MyClass( IoCContainer container)
    { 
       if (container == null)
          throw new ArgumentNullException("container");
    
       _container = container;
    }
