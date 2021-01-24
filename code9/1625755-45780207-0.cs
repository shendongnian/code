    public class Foo
    {
        public abstract int Result { get;  }
    }
    
    public class Bar : Foo
    {
        private const int field1 = 5;
        
    	public override int Result 
    	{ 
    		get {return field1; }
      	}
    }
    
    public class Baz : Foo
    {
        private const int field1 = 10;
    
    	public override int Result 
    	{ 
    		get {return field1; }
      	}
    }
