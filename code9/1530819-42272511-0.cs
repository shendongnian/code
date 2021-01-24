    public class TOL
    {
        [Key]
        public int TOL_ID { get; set; }
        public int Col1 { get; set; }
        public ICollection<TOR> Tors { get; set; }
    }
    public class TOR
    {
        [Key]
        public int TOR_ID { get; set; }
        public int Col1 { get; set; }
        public ICollection<TOL> Tols { get; set; }
    }
    public class TolTorContext : DbContext
    {
        public DbSet<TOL> Tols { get; set; }
        public DbSet<TOR> Tors { get; set; }
    }  
