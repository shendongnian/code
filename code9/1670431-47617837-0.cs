    public interface IFoo 
    {
        int A { get; set; }
        string B { get; set; }
    }
    
    public class Extended<T> : IFoo where T : IFoo, new()
    {
        IFoo foo = new T();
        
        public int A 
        {
            get { return foo.A; }
            set { foo.A = value; }
        }
        
        public string B
        { 
            get { return foo.B; }
            set { foo.B = value; }    
        }
        
        public bool D { get; set; }
    }
