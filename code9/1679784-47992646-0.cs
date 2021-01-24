    public partial class WeatherData : BaseModel
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VendorId { get; set; }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WeatherStationId { get; set; }
        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IntervalTypeId { get; set; }
        [StringLength(50)]
        public string VendorName { get; set; }
        [StringLength(50)]
        public string WeatherTypeCd { get; set; }
    }
