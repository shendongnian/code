    [Table("PerformanceSurchargeGeneralSettings")]
    public class PerformanceSurchargeGeneralSetting : FullAuditedEntity
    {
        [ForeignKey("PerformanceId")]
    	public virtual Performance Performance { get; set; }
        public int PerformanceId { get; set; }
    
    	[ForeignKey("SurchargeId")]
        public virtual Surcharge Surcharge { get; set; }
    	public int SurchargeId { get; set; }    
    }
---
    [Table("Surcharges")]
    public class Surcharge : FullAuditedEntity
    {
        [MaxLength(128)]
        public string Name { get; set; }
    
        public virtual ICollection<PerformanceSurchargeGeneralSetting> PerformanceSurchargeGeneralSettings{ get; set; }
    }
