    public partial class MyApplicationDbContext : DbContext
    {
        public MyApplicationDbContext()
            : base("name=MyApplicationDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        
        public static MyApplicationDbContext Create()
        {
            return new MyApplicationDbContext();
        } 
    
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
