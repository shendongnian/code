    public class Branch
    {
    	public int Id { get; set; }
    
    	[Required]
    	[Display(Name = "Branch Name")]
    	[StringLength(50)]
    	public string Name { get; set; }
    	
    	[Required]
    	[StringLength(50)]
    	public string Address { get; set; }
    
    	public List<Room> Rooms { get; set; }
    }
    public class Room
    {
    	public int Id { get; set; }
    
    	[Required]
    	public int RoomNumber { get; set; }
    
    	[Required]
    	[Range(5, 30)]
    	public int Capacity { get; set; }
    
    	public int BranchId { get; set; }
    
    	public Branch Branch { get; set; }
    }
