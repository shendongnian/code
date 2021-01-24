	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
	}
	
