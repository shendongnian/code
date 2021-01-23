    public class myContext : DbContext
    {
        public DbSet<myTable> myTables { get; set; }
        public myContext() : base("myConStr") { }
        public myContext setConnectionString(string ConnectionString)
        {
            this.Database.Connection.ConnectionString = ConnectionString;
            return this;
        }
        public myContext UpdateDatabase()
        {
            var Migrator = new DbMigrator(new Migrations.Configuration(){ TargetDatabase = new DbConnectionInfo(this.Database.Connection.ConnectionString, "System.Data.SqlClient") });
            IEnumerable<string> PendingMigrations = Migrator.GetPendingMigrations();
            foreach (var Migration in PendingMigrations)
                Migrator.Update(Migration);
            return this;
        }
    }
    static void Main(string[] args)
    {
       var db = new myContext()
           .setConnectionString("server=111.111.111.1111;Database=myDB;uid=sa;password=123456")
           .UpdateDatabase();
    }
