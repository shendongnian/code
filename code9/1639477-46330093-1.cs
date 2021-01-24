    public class Table3
    {
        // Not needed in 1:1
        // [Key]
        // public string Table3Code { get; set; }
        public string Table1Code { get; set; }
        public string Table2Code { get; set; }
        // Make this a collection for 1:M
        public virtual Table1_Table2 Table1_Table2 { get; set; }    
    }
