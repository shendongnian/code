    public abstract class EntityBase
    {
    	public long Id { get; set; }
    }
    public abstract class EntityTagBase
    {
    	public long TagId { get; set; }
    	public Tag Tag { get; set; }
    }
