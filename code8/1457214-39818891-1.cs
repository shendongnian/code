    public class RootObject
    {
        // Correctly not remapped
        public string StringValue { get; set; }
        // Correctly remaps to a GUID.
        public MyObject MyObject { get; set; }
 
        // Remap to a List<Guid> ?
        public List<MyObject> MyObjectList { get; set; }
        // Remap to a Dictionary<string, Guid> ?
        public Dictionary<string, MyObject> MyObjectDictionary { get; set; }
    }
    public class MyObject
    {
        public Guid Id { get; set; }
        public string Property2 { get; set; }
    }
