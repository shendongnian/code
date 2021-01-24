    public class EquipmentModel
    {
        public int Id {get; set;}
        // an EquipmentModel belongs to an ArmorModel via proper default foreign key
        public int ArmorModelId {get; set;}
        public virtual ArmorModel ArmorModel {get; set;}
        ...
    }
