    public class DerivedEntity : BaseEntity
    {
        public int Id { get; set; }
    }
    
    //...
    ConfigureBaseEntity(modelBuilder.Entity<DerivedEntity>());
