    public class MyClass
    {
        public int? MyInt { get; set; }
        public bool MyIntSpecified => MyInt.HasValue;
        public DateTime? MyDateTime { get; set; }
        public bool MyDateTimeSpecified => MyDateTime.HasValue;
    }
