        public class Db : DbContext
        {
    
            private readonly  SqlConnection con;
            public Db() {}
            public Db(SqlConnection con)
            {
                this.con = con;
                
            }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (con != null)
                {
                    optionsBuilder.UseSqlServer(con);
                }
                else
                {
                    optionsBuilder.UseSqlServer(@"Server=.;Database=EfCoreTest;Trusted_Connection=True;");
                }
    
            }
