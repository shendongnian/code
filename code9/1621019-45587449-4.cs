    public class PagedResults<T>
    {
        public int a { get; set; }
        public string b { get; set; }
        public int c { get; set; }
        ....
        ....
        public IEnumerable<T> Results { get; set; }
    }
