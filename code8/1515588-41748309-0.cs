    [DataContract]
    [KnownType(typeof(DerivedClass))]
    public class BaseClass {
        string Data { get; set; }
    }
    
    public class DerivedClass : BaseClass
    {
    }
