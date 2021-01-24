    public class SelfEntity
    {
    	public string Id { get; set; }
    	public string Name { get; set; }
    	public int Number;
    	public SelfEntity InnerSelfEntity { get; set; }
    }
    
    public class SelfModel
    {
    	public Guid Id { get; set; }
    	public string Name { get; set; }
    	public int Number;
    	public SelfModel InnerSelfModel { get; set; }
    }
