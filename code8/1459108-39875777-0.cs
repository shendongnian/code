    public class MyObject
    {
        [TypeConverter(typeof(MyTypeConverter))]
        public int MyProperty { get; set; }
    }
    public class MyTypeConverter : EnumConverter
    {
        public MyTypeConverter() : base(typeof(MyValues)) { }
    }
    public enum MyValues
    {
        On = 1,
        Off,
        Unknown
    }
