    public class EntityBase 
    {
      [SQLite.PrimaryKey, SQLite.AutoIncrement]
      public int? id { get; set; }
    }
    [SQLite.Table("table_sessions")]    
    public class table_sessions : EntityBase 
    {
        public string sessionid { get; set; }
        public DateTime created { get; set; 
    }
