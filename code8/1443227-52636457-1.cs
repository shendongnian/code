    public class myContext : DbContext
    {
        public DbSet<myTable> myTables { get; set; }
        public myContext() : base("myConStr") { }
        public void UpdateDatabase()
        {
            var Migrator = new DbMigrator(new Migrations.Configuration(){ TargetDatabase = new DbConnectionInfo(this.Database.Connection.ConnectionString, "System.Data.SqlClient") });
            IEnumerable<string> PendingMigrations = Migrator.GetPendingMigrations();
            foreach (var Migration in PendingMigrations)
                Migrator.Update(Migration);
        }
    }
    static void Main(string[] args)
    {
       var db = new myContext();
       db.UpdateDatabase();
    }
