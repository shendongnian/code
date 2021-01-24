    public interface IMyInterface
    {
        string MyProp { get; set; }
    }
    [Serializable]
    [Table("FooTable")]
    public class MYClass : IMyInterface
    {
        [Column("FooColumn")]
        [My(HeaderFields.MyValue)]
        public string MyProp { get; set; }
    }
    public enum HeaderFields
    {
        MyValue
    }
    public class MyAttribute : Attribute
    {
        #region CONSTRUCTORS
        public MyAttribute(object myValue) { }
        #endregion
    }
