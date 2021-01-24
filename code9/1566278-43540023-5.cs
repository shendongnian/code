    class CoreData
    {
        public int Id {get; set;}
        public ... NeverChangingItems {get; set;}
       
        public bool IsObsolete {get; set;}
        // data that might change through history
        // Each Core data contains a history of changed data
        public virtual ICollection<HistoricData> HistoricData {get; set;}
     }
     public class HistoricData
     {
          public int Id {get; set;}
          public DateTime AuditDate {get; set;}
          public ... ItemsThatChangeThroughoutHistory {get; set;}
          // foreign key to owning Core
          public int CoreDataId {get; set;}
          public virtual CoreData CoreData {get; set;}
     }
