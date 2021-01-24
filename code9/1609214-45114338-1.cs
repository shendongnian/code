    public class Example
    {
        public string number { get; set; }
        public int total { get; set; }
    }
    
    public class MyData
    {
        public Example Example { get; set; }
    }
    
    public class RootObject
    {
        public List<MyData> myData { get; set; }
    }
