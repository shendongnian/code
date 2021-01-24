       public class MyContext : DbContext
        {
            public DbSet<Animal> Animals { get; set; }
            public DbSet<Cage> Cages { get; set; }
        }
    
        public class Cage
        {
            public int CageID { get; set; }
            public virtual ICollection<Bird> Birds { get; set; }
        }
    
        public abstract class Animal
        {
            public int AnimalID { get; set; }
            public string Name { get; set; }
        }
    
        public class Bird : Animal
        {
            [ForeignKey("Cage"),Index(IsUnique =true)]
            public int CageID { get; set; }
            public Cage Cage { get; set; }
        }
    
        public class Shark : Animal
        {
            public int AquariumID { get; set; }
        }
