    public partial class tdCountry
    {
    	public tdCountry()
    	{
    		this.tePerson = new HashSet<tePerson>();
    	}
    
    	public int CountryId { get; set; }
    	public string CountryName { get; set; }
    
    	public virtual ICollection<tePerson> tePerson { get; set; }
    }
    public partial class tePerson
    {
    	public int PersonId { get; set; }
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    	public Nullable<int> CountryId { get; set; }
    
    	public virtual tdCountry tdCountry { get; set; }
    }
