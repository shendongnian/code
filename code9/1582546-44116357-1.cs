    public class FirstObjectType
    {
        public string Name { get; set; }
    }
    
    public class SecondObjectType
    {
        public string Label { get; set; }
    }
    
    public class RootObject
    {
        public List<FirstObjectType> FirstObjectType { get; set; }
        public List<SecondObjectType> SecondObjectType { get; set; }
    }
