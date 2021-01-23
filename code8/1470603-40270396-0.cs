        public class Device
                { 
                    public Device() 
                    { this.Equipments = new HashSet<Equipment>();}
                    [Key]
                    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
                    public int InternalDeviceID { get; set; }
            
                    public int DeviceID { get; set; }
            
                    public string DeviceName { get; set; }
            
                    public virtual ICollection<Equipment> Equipments { get; set; }
                }
        
        public class Equipment
            {
                public Equipment()
                { this.Devices = new HashSet<Device>(); }
 
                [Key]
                [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
                public int InternalEquipmentID { get; set; }
        
                public int EquipmentID { get; set; }
        
                public string EquipmentName { get; set; }
        
                public virtual ICollection<Devices> Devices { get; set; }
            }
