    void Main()
    {
        MyClass c = new MyClass();
        string val = string.Empty;
        if (c.PossiblyNullDictionary?.TryGetValue("someKey", out val) ?? false)
        {
    
            Console.WriteLine(val);
    
        }
    }
    public class MyClass {
        public Dictionary<string, string> PossiblyNullDictionary;
    }
    // Define other methods and classes here
