    [DelimitedRecord(",")]
    [IgnoreEmptyLines]
    public class MySpec
    {
        public string Column1;
        public string Column2;
        public string Column3;
        public string Column4;
        public string Column5;
        [FieldOptional]
        public string Dummy;
    }
