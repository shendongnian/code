    public abstract class FarmerChangeBase
    {
    	public int LastChangeByFarmerId { get; set; }
    	public DateTime LastChangeTimestamp { get; set; }
    	[ForeignKey("LastChangeByFarmerId")]
    	public virtual Farmer LastChangeFarmer { get; set; }
    }
    public class Chicken : FarmerChangeBase
    {
    	[Key]
    	public int ChickenId { get; set; }
    	public bool IsRooster { get; set; }
    }
    
    public class Cow : FarmerChangeBase
    {
    	[Key]
    	public int CowId { get; set; }
    	public string Name { get; set; }
    }
