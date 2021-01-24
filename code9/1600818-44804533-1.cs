    public class MyNestedObject {
        public string NestedName { get; set; }
        public bool IsEnabled { get;  set; }
    }
    public class MyResponseObject {
        public List<MyNestedObject> NestedObjects { get; set; }
 
    }
