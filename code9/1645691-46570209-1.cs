    public class InheritanceBaseEntity
    {
        public int Id { get; set; }
        public int BaseEntityProperty { get; set; }
    }
    public class InheritanceDerivedEntity : InheritanceBaseEntity
    {
        public int DerivedEntityProperty { get; set; }
    }
    public DbSet<InheritanceBaseEntity> InheritanceBaseEntities { get; set; }
    public DbSet<InheritanceDerivedEntity> InheritanceDerivedEntities { get; set; }
    // use .OfType<InheritanceDerivedEntity>() to get entities that have a 
    //     non-null 'value' for the related properties
    var inheritanceEntities = dbContext.Set<InheritanceBaseEntity>().ToArray();
