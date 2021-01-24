    public class AVLdataContext : DbContext
    {
        public AVLdataContext ()
            : base("AVLdataContext")
        {
        
        }
    
        public DbSet<Datas> Data { get; set; }
        public DbSet<GPSelement> GPSelement { get; set; }
        public DbSet<IOelement> IOelement { get; set; }
    }
