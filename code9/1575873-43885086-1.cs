      [Table("Org")]
       public class Org
        {
            [Key]
            public int Id { get; set; }
            [Required)]
            public string Name { get; set; }
            public string Website { get; set; }
            public string Address { get; set; }
        }
    **DbContext:**
    
        public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {           
        }
      public DbSet<Org> Orgs { get; }
    
    }
