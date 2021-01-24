    public class Product
    {
        public string SKU { get; set; }
        public ExtraInfo[] Extras { get; set; }
        public class ExtraInfo
        {
            public string Code { get; set; }
            public object Value { get; set; }
        }
    }
