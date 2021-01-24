    public class MyViewModel()
    {
        protected MyViewModel()
        {
            //both runtime and design time logic. 
            //you may use IsDesignMode check if needed
        }
    
        public MyViewModel(ISomeExternalResource externalResource) : this();
        {
            //this is executed only at run time
            _externalResource = externalResource;
            Items = externalResouce.GetAll();
        }
    
        public List<string> Items {get; protected set;}
    }
    
    public class MyViewModelDesignTime : MyViewModel
    {
        public MyViewModelDesignTime () : base()
        { 
            //this will be show in the designer
            Items = new List<string> { "Item1", "Item2" };
        }
    }
