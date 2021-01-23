    public class Settings
    {
        // a primary key is necessary.
    	public int Id { get; set; }
    	[NotMapped]
    	public Hashtable Hash
    	{
    		get;
    		set;
    	}
        // the backing field can be protected, this helps 'hide' it.
    	protected virtual byte[] _Hash
    	{
    		get
    		{
    			return Extensions.ToBinary(Hash);
    		}
    		set		
    		{
    			Hash = (Hashtable)Extensions.FromBinary(value);
    		}
    	}
    }
