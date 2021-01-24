	public class Contact
	{
		public int ConctactId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string City { get; set; }
		
		public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
	}
	public class PhoneNumber
	{
		public int PhoneNumberId { get; set; }
		public string Number { get; set; }
		public string Description { get; set; }
		public PhoneNumberTypeEnum EnumType { get; set; }
		
		public int ContactId {get; set;}
		
		public virtual Contact Contact{get; set;}
	}
