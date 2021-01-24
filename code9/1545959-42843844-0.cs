    [Table("JobRequest")]
    public partial class JobRequest
    {
    	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    	public long? ID { get; set; }
    
    	[Key]
    	[StringLength(15)]
    	[DisplayName("Request Number")]
    	public string RequestNumber { get; set; }
    
    	public virtual WorkOrder WorkOrder { get; set; }
    }
    
    [Table("WorkOrder")]
    public partial class WorkOrder
    {
    	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    	public long? ID { get; set; }
    
    	[Key]
    	[StringLength(25)]
    	[DisplayName("Work Order Number")]
    	public string WONumber { get; set; }
    	public virtual JobRequest JobRequest { get; set; }
    }
