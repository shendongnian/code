    public class Device
    {   
        [Key]
        public int DeviceID { get; set; }
        public string DeviceName { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; }
    }
    public class Equipment
    {        
        [Key]
        public int EquipmentID { get; set; }
        public string EquipmentName { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
    }
