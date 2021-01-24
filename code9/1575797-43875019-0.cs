    public class Product
    {
        public string col1 { get; set; }
        public string col2 { get; set; }
    }
    public class Sample
    {
        public string col3 { get; set; }
        public string col4 { get; set; }
    }
    public class Root
    {
        public Product Product { get; set; }
        public Sample[] Samples { get; set; }
    }
