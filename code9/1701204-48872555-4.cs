    public class Table1 {
        public string Table2PseudoKey {get; set;}
        [ForeignKey("Table2PsuedoKey")]
        public virtual Table2Alternate Table2 {get; set;}
    }
