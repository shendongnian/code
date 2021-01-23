    public class TableVM
    {
        public TableVM()
        {
            Variants = new List<RowVM>();
        }
        public string Title { get; set; }
		public IEnumerable<string> Headers { get; set; }
        public List<RowVM> Variants { get; set; }
        // The following properties are used for 'grouping' your data
        public string Sequence { get; set; }
        public bool IsSequential { get; set; }
		public int MaxColumns { get; set; }
    }
    public class RowVM
    {
        public RowVM()
        {
            Fluctuations = new List<ColumnVM>();
        }
        public string Variant { get; set; }
        public List<ColumnVM> Fluctuations { get; set; }
    }
    public class ColumnVM
    {
        public decimal Fluctuation { get; set; }
    }
