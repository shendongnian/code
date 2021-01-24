    namespace Project.Auth{
	public class PhoneNumberAuthenticationOptions : AuthenticationSchemeOptions
	{
		public Regex PhoneMask { get; set; }// = new Regex("7\\d{10}");
	}}
