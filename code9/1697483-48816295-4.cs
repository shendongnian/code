    public partial class BillMarkContext : DbContext
    {
        private static string _connection4 = "Integrated Security=True;Persist Security Info=True;Initial Catalog=MyDB;Data Source=MyServer";
        public BillMarkContext()
            : base(_connection4)
        {
            //Since we're read-only
            Database.SetInitializer<BillMarkContext>(null);
        }
        //View property setup since we're read-only
        protected virtual DbSet<BillMarkCode> _billMarkCodes { get; set; }
        public DbQuery<BillMarkCode> BillMarkCodes
        {
            get { return Set<BillMarkCode>().AsNoTracking(); }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { }
    }
