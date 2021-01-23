    public class Program
    {
    	protected Dictionary<ScriptableObject, string> dict = new Dictionary<ScriptableObject, string>();
    }
    public class ProgramChild1 : Program
    {
    	public void Test()
    	{
    		dict.Add(MyEnum1.One, "One");
    		dict.Add(MyEnum1.Two, "Two");
    		dict.Add(MyEnum1.Three, "Three");
    		string result;
        	dict.TryGetValue(MyEnum1.Two, out result);
    	}	
    }
    
    public class ProgramChild2 : Program
    {
    	
    	public void Test()
    	{
    		dict.Add(MyEnum2.Four, "One");
    		dict.Add(MyEnum2.Five, "Two");
    		dict.Add(MyEnum2.Six, "Three");
    		string result;
        	dict.TryGetValue(MyEnum2.Five, out result);
    	}
    }
    //Each class goes in to its own .cs file, Put them in two folders `MyEnum1` and `MyEnum2`
    namespace MyEnum1
    {
        public One class : ScriptableObject
        {
        }
    }  
     
    namespace MyEnum1
    {
        public class Two : ScriptableObject
        {
        }
    }
    
    namespace MyEnum1
    {    
        public class Three : ScriptableObject
        {
        }
    }
    
    namespace MyEnum2
    {    
        public class Four : ScriptableObject
        {
        }
    }
    
    namespace MyEnum2
    {    
        public class Five : ScriptableObject
        {
        }
    }
    
    namespace MyEnum2
    {    
        public class Six : ScriptableObject
        {
        }
    }
