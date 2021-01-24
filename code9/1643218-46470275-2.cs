        public class MyContext : DbContext
        {
            public DbSet<Animal> Animals { get; set; }
            public DbSet<Cage> Cages { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
    
                modelBuilder.Entity<Bird>().HasOptional(b => b.Cage).WithRequired(c => c.Bird);
            }
        }
    
        public class Cage
        {
            [Key]
            public int CageId { get; set; }
    
           
            [ForeignKey("CageId")]
            public virtual Bird Bird { get; set; }
        }
    
        public abstract class Animal
        {
            public int AnimalID { get; set; }
            public string Name { get; set; }
        }
    
        public class Bird : Animal
        {
            public Cage Cage { get; set; }
        }
    
        public class Shark : Animal
        {
            public int AquariumID { get; set; }
        }
