    public class AnyClass
    {
        //This value is the one to be compared with ColumnA
        public int? ValueToCompare { get; set; }
        public int ColumnA { get; set; }
        //ColumnB will throw a result based on two columns above
        public string ColumnB { get { return ValueToCompare.HasValue && ValueToCompare.Value <= ColumnA ? "PASS" : "FAILED"; } }
    }
