    public class Table1
    {
        [Key]
        public string Table1Code { get; set; }
    
        public virtual List<Table3> Table3 { get; set; }
    }
    
    public class Table2
    {
        [Key]
        public string Table2Code { get; set; }
    
        public virtual List<Table3> Table3 { get; set; }    
    }
     public class Table3
    {
        [Key]
        public string Table3Code { get; set; }
    
        public Table1 Table1 { get; set; }
        public string Table1Code { get; set; }
        public Table2 Table2 { get; set; }
        public string Table2Code { get; set; }
    }
