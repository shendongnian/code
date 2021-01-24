        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=yorudbname.db");
        }
        //ONLY necessary if you needing to use Fluent API
        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);   //required reference comment - Order Matters as well.
                                        //ie has to be at the top.
