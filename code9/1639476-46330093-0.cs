    public class Table1_Table2
    {
        public string Table1Code { get; set; }  // PK 1
        public string Table2Code { get; set; }  // PK 2
        public virtual Table3 Table3 { get; set; }    
    }
