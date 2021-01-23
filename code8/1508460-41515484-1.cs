    public class Program
    {
    	protected Dictionary<ScriptableObject, string> dict = new Dictionary<ScriptableObject, string>();
    }
    public class ProgramChild1 : Program
    {
    	public void Test()
    	{
    		dict.Add(MyEnum1.One.Instance, "One");
    		dict.Add(MyEnum1.Two.Instance, "Two");
    		dict.Add(MyEnum1.Three.Instance, "Three");
    		string result;
        	dict.TryGetValue(MyEnum1.Two.Instance, out result);
    	}	
    }
    
    public class ProgramChild2 : Program
    {
    	
    	public void Test()
    	{
    		dict.Add(MyEnum2.Four.Instance, "One");
    		dict.Add(MyEnum2.Five.Instance, "Two");
    		dict.Add(MyEnum2.Six.Instance, "Three");
    		string result;
        	dict.TryGetValue(MyEnum2.Five.Instance, out result);
    	}
    }
    //Each class goes in to its own .cs file, Put them in two folders `MyEnum1` and `MyEnum2`
    namespace MyEnum1
    {
        public class One : ScriptableObject
        {
            private static One _inst;
            public static One Instance
            {
                get
                {
                    if (!_inst)
                        _inst = Resources.FindObjectOfType<One>();
                    if (!_inst)
                        _inst = CreateInstance<One>();
                    return _inst;
                }
            }
        }
    }  
     
    namespace MyEnum1
    {
        public class Two : ScriptableObject
        {
            private static Two _inst;
            public static Two Instance
            {
                get
                {
                    if (!_inst)
                        _inst = Resources.FindObjectOfType<Two>();
                    if (!_inst)
                        _inst = CreateInstance<Two>();
                    return _inst;
                }
            }
        }
    }
    
    namespace MyEnum1
    {    
        public class Three : ScriptableObject
        {
            private static Three _inst;
            public static Three Instance
            {
                get
                {
                    if (!_inst)
                        _inst = Resources.FindObjectOfType<Three>();
                    if (!_inst)
                        _inst = CreateInstance<Three>();
                    return _inst;
                }
            }
        }
    }
    
    namespace MyEnum2
    {    
        public class Four : ScriptableObject
        {
            private static Four_inst;
            public static Four Instance
            {
                get
                {
                    if (!_inst)
                        _inst = Resources.FindObjectOfType<Four>();
                    if (!_inst)
                        _inst = CreateInstance<Four>();
                    return _inst;
                }
            }
        }
    }
    
    namespace MyEnum2
    {    
        public class Five : ScriptableObject
        {
            private static Five _inst;
            public static Five Instance
            {
                get
                {
                    if (!_inst)
                        _inst = Resources.FindObjectOfType<Five>();
                    if (!_inst)
                        _inst = CreateInstance<Five>();
                    return _inst;
                }
            }
        }
    }
    
    namespace MyEnum2
    {    
        public class Six : ScriptableObject
        {
            private static Six _inst;
            public static Six Instance
            {
                get
                {
                    if (!_inst)
                        _inst = Resources.FindObjectOfType<Six>();
                    if (!_inst)
                        _inst = CreateInstance<Six>();
                    return _inst;
                }
            }
        }
    }
