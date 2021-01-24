    class Equipment
    {
        public int Id {get; set;}
        ...
        // every equipment has zero or more Components (many-to-many)
        public virtual ICollection<Component> Components {get; set;}
    }
    class Component
    {
        public int Id {get; set;}
        public string Name {get; set;}
        // Every Component belongs to zero or more Equipments (many-to-many)
        public virtual ICollection<Equipment> Equipments {get; set;}
    }
    class MyDbcontext : DbContext
    {
        public DbSet<Equipment> Equipments {get; set;}
        public DbSet<Component> Components {get; set;}
    }
