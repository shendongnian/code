    public class C1
    {
        public List<string> skills { get; set; }
    }
    public class C2
    {
        public List<string> skills { get; set; }
    }
    public class Category
    {
        public C1 c1 { get; set; }
        public C2 c2 { get; set; }
    }
    public class DataItem
    {
        public string track { get; set; }
        public Category category { get; set; }
    }
	
	
