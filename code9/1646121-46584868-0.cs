    public class Module
    {
    	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    	public Guid Id { get; set; } /* primary key */
    	public Guid? OtherModule1 { get; set; }
    	[ForeignKey("OtherModule1")]
    	public Module OtherModule { get; set; }
    
    	[Column("OtherModule2")]
    	public Guid? OtherModule2_Id { get; set; }
    	[ForeignKey("OtherModule2_Id")]
    	public Module OtherModule2 { get; set; }
    }
