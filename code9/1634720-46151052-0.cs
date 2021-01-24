	class Program
	{
		static void Main(string[] args)
		{
			Guest guest = new Guest { Email = "", FirstName = "tom", GuestID = 1 };
			List<Address> AddressList = new List<Address>();
			Address address1 = new Address { AddressID = 1, AddressType = "1", GuestID = 1, IsPrimaryAddress = false, Address1 = "address1" };
			Address address2 = new Address { AddressID = 2, AddressType = "2", GuestID = 1, IsPrimaryAddress = true, Address1 = "address2" };
			AddressList.Add(address1);
			AddressList.Add(address2);
			var primaryAddress = AddressList.Where(x => x.GuestID == guest.GuestID && x.IsPrimaryAddress == true);
			var secAddress = AddressList.Where(x => x.GuestID == guest.GuestID && x.IsPrimaryAddress == false);
			var rueryResult = from pAddress in primaryAddress
							  join sAddress in secAddress on pAddress.GuestID equals sAddress.GuestID
							  select new GuestAddress
		                   	{
			                	GuestID = pAddress.GuestID,
				                IsPrimaryAddress = pAddress.IsPrimaryAddress,
				                Address1 = pAddress.Address1,
				                SecondayAddress = sAddress.Address1,
				                IsSecondayAddress = sAddress.IsPrimaryAddress
			                 };
		}
	}
	public class Guest
	{
		public int GuestID { get; set; }
		public string FirstName { get; set; }
		public string Email { get; set; }
	}
	public class Address
	{
		public int AddressID { get; set; }
		public int GuestID { get; set; }
		public string AddressType { get; set; }
		public bool IsPrimaryAddress { get; set; }
		public string Address1 { get; set; }
	}
	public class GuestAddress
	{
		public int GuestID { get; set; }
		public bool IsPrimaryAddress { get; set; }
		public bool IsSecondayAddress { get; set; }
		public string Address1 { get; set; }
		public string SecondayAddress { get; set; }
	}
