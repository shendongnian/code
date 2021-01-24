    public class TableB
    {
        public int Id { get; set; }
        public virtual IList<TableA> TableItemAList { get; set; }
        public virtual IList<TableA> TableItemBList { get; set; }
    }
