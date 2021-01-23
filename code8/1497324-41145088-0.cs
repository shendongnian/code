	[Table("appUser")]
	public class AppUser
	{
		public AppUser()
		{
			this._AccessRights = new HashSet<AccessRight>();
			this._ActivityLog = new HashSet<ActivityLog>();
		}
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int userId { get; set; }
		// ... other properties
		
		public void Add()
		{
			using (var cntx = new JEntityDbContext())
			{
				cntx.AppUsers.Add(this);
				cntx.SaveChanges();
			}
		}
		public void Read()
		{ 
		}
	}
