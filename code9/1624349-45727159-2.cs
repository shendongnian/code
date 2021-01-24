    [Serializable]
    [Table("FooTable")]
    public class MYClass : IMyInterface
    {
        [Column("FooColumn")]
        [My(HeaderFields.MyValue)]
        public string MyProp { get; set; }
    }
    public class MyAttribute : Attribute
    {
        public MyAttribute(object myValue) { }
    }
    public enum HeaderFields
    {
        MyValue,
        MyAnotherValue
    }
    public interface IMyInterface
    {
        string MyProp { get; set; }
    }
