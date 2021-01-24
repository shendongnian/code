    using SQLite;
    using ORMLite = ServiceStack.DataAnnotations;
    [ORMLite.PrimaryKey, ORMLite.AutoIncrement]
    [SQLite.PrimaryKey, SQLite.AutoIncrement]
    public int Id { get; set; }
    
    [Indexed,Index]
    public string UserAccountId { get; set; }
