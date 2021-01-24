    public class Dictionary
    {
    	public object this[object index] {
    		get {return null;}
    		set {}
    	}
    }
    static void Main()
    {
	    Class1 class1 = new Class1();
     	Class2 class2 = new Class2();
	    var dictionary = new Dictionary 
        {
            [class1] = class1, 
            [class2] = class2
        };
    }
