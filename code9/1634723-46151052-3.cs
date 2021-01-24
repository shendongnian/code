     namespace ConsoleApplication1
     {
	  class Program
	  {
		static void Main(string[] args)
		{
			Guest guest1 = new Guest { Email = "tom@gmail.com", FirstName = "tom", GuestID = 1 };
			Guest guest2 = new Guest { Email = "jerry@gmail.com", FirstName = "jerry", GuestID = 2 };
			List<Guest> listGuests = new List<Guest>();
			listGuests.Add(guest1);
			listGuests.Add(guest2);
			List<Address> AddressList = new List<Address>();
			Address address1 = new Address { AddressID = 1, AddressType = "1", GuestID = 1, IsPrimaryAddress = false, Address1 = "address1" };
			Address address2 = new Address { AddressID = 2, AddressType = "2", GuestID = 1, IsPrimaryAddress = true, Address1 = "address2" };
			Address address3 = new Address { AddressID = 1, AddressType = "1", GuestID = 2, IsPrimaryAddress = true, Address1 = "address3" };
			Address address4 = new Address { AddressID = 1, AddressType = "1", GuestID = 2, IsPrimaryAddress = false, Address1 = "address4" };
			AddressList.Add(address1);
			AddressList.Add(address2);
			AddressList.Add(address3);
			AddressList.Add(address4);
			var queryResult = from primaryAddress in ( AddressList.Where(x => x.IsPrimaryAddress == true))
							  join secAddress in (AddressList.Where(x => x.IsPrimaryAddress == false))
							  on primaryAddress.GuestID equals secAddress.GuestID
							  join guest in listGuests on  secAddress.GuestID equals guest.GuestID
							  select new GuestAddress
								{
									FirstName = guest.FirstName,
									Email = guest.Email,
									GuestID = primaryAddress.GuestID,
									IsPrimaryAddress = primaryAddress.IsPrimaryAddress,
									Address1 = primaryAddress.Address1,
									SecondayAddress = secAddress.Address1,
									IsSecondayAddress = secAddress.IsPrimaryAddress
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
		public string FirstName { get; set; }
		public string Email { get; set; }
		public int GuestID { get; set; }
		public bool IsPrimaryAddress { get; set; }
		public bool IsSecondayAddress { get; set; }
		public string Address1 { get; set; }
		public string SecondayAddress { get; set; }
	}
}
