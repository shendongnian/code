    namespace B
    {
    	public class Class1
    	{
    #if HASA
    		private static A.Class1 _otherA = new A.Class1();
    #endif
    	}
    }
