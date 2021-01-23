    public class Device
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceNumber { get; set; }
    
        [ForeignKey("ManufacturerNumber")]
        public virtual Manufacturer Manufacturer { get; set; }
    
        [Required]
        public int ManufacturerNumber { get; set; }
    
        [ForeignKey("CarrierNumber")]   
        public virtual Carrier Carrier { get; set; }
    
        [Required]
        public int CarrierNumber { get; set; }
    
        [Required]
        public string Name { get; set; }
    }
