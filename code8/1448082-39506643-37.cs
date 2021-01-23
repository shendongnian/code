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
	    		return Hash.ToBinary();
		    }
    		set		
	    	{
		    	Hash = value.FromBinary<Hashtable>();
    		}
	    }
    }
