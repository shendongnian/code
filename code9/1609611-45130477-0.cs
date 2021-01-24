    public class RootObject
    {
        public List<MyObject> MyArray { get; set; }
    }
    public class MyObject
    {
        public MyType MyValue { get; set; }
    }
    
    //I assume this because there's not info about "MyType"
    public class MyType : String { }
