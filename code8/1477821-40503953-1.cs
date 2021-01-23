    public class ListCode : List<int>
    {
        public ListCode(IEnumerable<int> content) : base(content) { }
        public string Code { get; set; }
    }
