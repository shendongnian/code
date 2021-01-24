    class TableData
    {
        DateTime? AuditDate {get; set;} // used to order by date. null if never audited
        ...
    }
    class CoreData
    {
        public int Id {get; set;}     // int may be any other type
        public TableData {get; set;}  // all untouched items should have this
                                      // all others: choose what you want
        ...
    }
    class AuditData
    {
        public DateTime AuditDate {get; set;}
        public int CoreId {get; set;}
        public TableData {get; set;}  // all deleted items should have this
                                      // all others: choose what you want
        ...
    }
    IEnumerable<CoreData> coreData = ...
    IEnumerable<AutidData> auditedData = ...
