	public class Organisation
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Location> Locations { get; set; }
	}
	
	public class Location
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsHqLocation { get; set; }
		public int OrganisationId { get; set; }
		public Organisation Organisation { get; set; }
	}
