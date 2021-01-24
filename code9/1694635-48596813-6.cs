    public class UserSelfDeleteViewModel
	{
		[Editable(false)]
		[Display(Name = "Email address")]
		public string Email { get; set; }
		[Editable(false)]
		[Display(Name = "User name")]
		public string UserName { get; set; }
		[Required]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
    }
