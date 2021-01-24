    public abstract class MasterBaseDocument
    {       
    	public int ID { get; set; }
    	[Required]
    	[Display(Name = "EStandard")]
    	[StringLength(50)]
    	public string EStandard { get; set; }
    	[Required]
    	[Column("Betegnelse")]
    	[Display(Name = "Betegnelse")]
    	[StringLength(60)]
    	public string Betegnelse { get; set; }
    	[Display(Name = "Kommentar")]
    	public string Comment { get; set; }
    }
    
    public class Form : MasterBaseDocument
    {
    	...
    }
    public class Standard : MasterBaseDocument
    {
    	...
    }
    
    public class MasterDocument : MasterBaseDocument
    {
    	// right now, empty here...
    }
