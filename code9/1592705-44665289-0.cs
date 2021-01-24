	[FileHelpers.DelimitedRecord(",")]
	public class Orders
	{
		[FileHelpers.FieldQuoted]
		public string CompanyName;
		public string Email;
		[FileHelpers.FieldQuoted]
		public string JobTitle;
		public string CompanyType;
		public string City;
		public string FirstName;
		public string LastName;	
	}
