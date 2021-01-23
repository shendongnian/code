     public class AssetRequest
        {
            public int Id { get; set; }
    
            [DataType(DataType.Date)]
            [Display(Name = "Request date")]
            public DateTime AssetRequestDate { get; set; }
    
    
    
            [Display(Name = "Facility")]
            public int FacilityId { get; set; }
            public virtual Facility Facility { get; set; }
     public class Facility
        {
            public int Id { get; set; }
    
    
            [Display(Name="Asset")]
            public string AssetName { get; set; }
    
            public virtual ICollection<AssetRequest> AssetRequests { get; set; }
        }
    public DbSet<AssetRequest> AssetRequestTable { get; set; }
            public DbSet<Asset> AssetTable { get; set; }
    
            public DbSet<District> DistrictTable { get; set; }
