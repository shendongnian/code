    [DataContract]
    [KnownType(typeof(DerivedClass))]
    public class BaseClass 
    {
        string Data { get; set; }
    }
    [DataContract(Name="DerivedType")]
    public class DerivedClass : BaseClass 
    {
        string MoreData { get; set; }
    }
