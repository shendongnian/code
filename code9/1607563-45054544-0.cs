    class ArmorModel
    {
        public int Id {get; set;}
        
        // an ArmorModel has many EquipmentModels
        public virtual ICollection>EquipmentModel> EquipmentModels {get; set;}
        ...
    }
    public class EquipmentModel
    {
        public int Id {get; set;}
        // an EquipmentModel belongs to an ArmorModel via foreign key
        public int EquipmentId {get; set;}
        public virtual ArmorModel ArmorModel {get; set;}
        ...
    }
    public class MyDbContext : DbContext
    {
        public DbSet<EquipmentModel> EquipmentModels {get; set;}
        public DbSet<ArmorModel> ArmorModels {get; set;}
    }
