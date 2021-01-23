	public class ApplicationUser : IdentityUser
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]    
		public long OrgId { get; set; }
		
		// Indicates that OrgId is foreign key for Organization navigation property
		[ForeignKey("OrgId")] 
		public virtual Organizations Organization { get; set; }
		
		....
	}	
	
	public class Organizations
	{
		[Key]
		public long OrganizationId { get; set; }
		public string OrganizationName { get; set; }
		public virtual ICollection<ApplicationUser> Users { get; set; }
	}
	
