    /// <summary>
    /// Model for Party, which is general form of Persons and Companies
    /// </summary>
    public class Party
    {
		public int PartyID { get; set; }
		
        // Navigation properties
        public virtual Company Company { get; set; }
        public virtual Person Person { get; set; }
		public virtual Contact Contact { get; set; }
    }
	
    public class Person
    {
		public int PersonID { get; set; }
		// Other properties.....
		
        // Navigation properties
        public virtual Party Party { get; set; }
    }
	
    public class Company
    {
		public int CompanyID { get; set; }
		// Other properties
	
        // Navigation properties
        public virtual Party Party { get; set; }
    }
	
	public class Contact
	{
		public int ContactID { get; set; }
		// Other properties...
		
		// Navigation properties
        public virtual Party Party { get; set; }
	}
