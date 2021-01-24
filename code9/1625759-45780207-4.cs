    public abstract class Foo
    {
        public abstract int Result { get;  }
    }
    
    public class Bar : Foo
    {
        // This is implementation specific. Hide it.
        private const int field1 = 5;
        
    	public override int Result 
    	{ 
    		get { return field1; }
      	}
    }
    
    public class Baz : Foo
    {
    	public override int Result 
    	{ 
            // No need for this implementation to be a constant ...
     		get { return TheResultOfAReallyComplexCalculationHere(); }
      	}
    }
