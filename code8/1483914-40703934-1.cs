    public partial class MyContext : DbContext
    {
        static MyContext()
        {
             DbInterception.Add(new FtsInterceptor());
        }
        public MyContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            // ....
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NoteMap());
        }
    }
