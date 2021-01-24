    public class Frame
    {
    	[Key, Column(Order = 0)]
    	public int Moulding_Id { get; set; }
    
    	[Key, Column(Order = 1)]
    	public int FrameType_Id { get; set; }
    	
    	[ForeignKey("Moulding_Id")]
    	public Moulding Moulding { get; set; }
    
    	[ForeignKey("FrameType_Id")]
    	public FrameType FrameType { get; set; }
    
    	public ICollection<Product> Products { get; set; }
    }
    public class Product
    {
    	public int Id { get; set; }
    
    	public int Moulding_Id { get; set; }
    
    	public int FrameType_Id { get; set; }
    
    	[ForeignKey("Moulding_Id")]
    	public Moulding Moulding { get; set; }
    
    	[ForeignKey("FrameType_Id")]
    	public FrameType FrameType { get; set; }
    
    	[ForeignKey("Moulding_Id,FrameType_Id")]
    	public Frame Frame { get; set; }
    }
