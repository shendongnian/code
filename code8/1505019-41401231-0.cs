    public class NewSomeClass 
    {
        private SomeClass inner;
        public NewSomeClass(SomeClass inner)
        {
          this.inner = inner;
        }
    
        public Sth GetByKey(SomeKey key) 
        {
            return this.inner.GetByKey(key.Value);
        }
    }
    
    public class SomeKey
    {    
       public SomeKey(string val)
       {
          this.Value = val;
       }
       public string Value {get;}
    
       public static readonly SomeKey Abc = new SomeKey("Abc");
    
       public static readonly SomeKey Xyz = new SomeKey("Xyz");
    }`
