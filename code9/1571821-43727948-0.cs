    public class DeviceFeature
    {
        [Display(Name = "ID")]
        public int DeviceFeatureID { get; set; }
        [Required]        
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<DeviceType> DeviceTypes { get; set; }
        public virtual ICollection<UserDeviceFeatureStatus> UserDeviceFeatureStatuses { get; set; }
    }
    
    public class UserDevice
    {
        public int UserDeviceID { get; set; }
        public int DeviceTypeID { get; set; }
        public string UserID { get; set; }
        public string DeviceName { get; set;}
        public virtual ICollection<UserDeviceFeatureStatus> UserDeviceFeatureStatuses { get; set; }
    }
    public class UserDeviceFeatureStatus
    {
        public int UserDeviceID { get; set; }
        public int DeviceFeatureID { get; set; }
        public virtual UserDevice UserDevice { get; set; }
        public virtual DeviceFeature DeviceFeature { get; set; }
        public string CurVal { get; set; }
        public string NewVal { get; set; }
    }
