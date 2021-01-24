     public class BaseEventTemplate {
            public string name { get; set; }
        }
    public class EventTemplate1 : BaseEventTemplate {
        // ..... other members 
        public string template1 { get; set; }
    }
    
    public class EventTemplate2: BaseEventTemplate {
        // ..... other members 
        public string template2 { get; set; }
    }
    public class EventData<T> where T : BaseEventTemplate {
      protected T _context;
    // ..... other  
    public EventData(T t)
    {
        this._context = t;
    }
    // ..... other members 
    public T Context
    {
        get { return _context; }
        set { _context = value; }
    }
