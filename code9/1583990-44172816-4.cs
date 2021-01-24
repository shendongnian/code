    public class A
    {
        public string Name { get; set; }
        public IEnumerable<B> Children { get; set; }
        public IEnumerable<B> SortedChildren { get { return Children.OrderBy(ca => ca.Name); } }
    }
        
    public class B
    {
        public string Name { get; set; }
    }
