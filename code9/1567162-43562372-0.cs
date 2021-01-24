    public class DeviceType
    {
        public DeviceType() 
        {
            this.DeviceFeatures = new HashSet<DeviceFeature>();
        }
        [Display(Name = "ID")]
        public int DeviceTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<DeviceFeature> DeviceFeatures { get; set; }
    }
    public class DeviceFeature
    {
        public DeviceFeature() 
        {
            this.DeviceTypes = new HashSet<DeviceType>();
        }   
        [Display(Name = "ID")]
        public int DeviceFeatureID { get; set; }
        [Required]        
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<DeviceType> DeviceTypes { get; set; }
    }
