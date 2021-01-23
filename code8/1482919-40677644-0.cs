    //This _assumes_ you're allowed to use Generics, seems impossible otherwise as A.GetName would compile to C.GetName
    void Main()
    {
    	A.GetName().Dump(); //A
    	B.GetName().Dump(); //B
    	new A();new A();new A();new A();
    	new B();
    	//For part 2 I'm not 100% sure what number is wanted	
    	baseC.TotalCount.Dump(); //5 
    	A.Count.Dump(); //4
    	B.Count.Dump(); //1
    }
    
    abstract class baseC 
    //cant think of any way to stop something other than C inheriting unless in own assembly
    // if TotalCount is not the one wanted this can be dropped
    {
    	public static int TotalCount {get; protected set;} //Must be in the non-generic part so only one copy
    }
    
    abstract class C<T> : baseC where T: C<T> //Hopefully enough to FORCE A to inherit C<A> etc
    {
    	public static int Count {get; private set;}
    	public static string GetName() 
    	{
    		return typeof(T).Name;
    	}
    	protected C() 
    	{ 
    		TotalCount++;
    		Count++;
    	}
    }
