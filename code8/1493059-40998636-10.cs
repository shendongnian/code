	public class CustomerModel
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int[] BoodkingType { get; set; }
	}
	public class BoodkingTypeModel
	{
		public int ID { get; set; }
		public string Name { get; set; }
	}
	public static class DummyDatabase
	{
		public static IEnumerable<BoodkingTypeModel> BoodkingTypes { get; } = new BoodkingTypeModel[]
		{
			new BoodkingTypeModel { ID=1, Name="Type1"  },
			new BoodkingTypeModel { ID=2, Name="Type2"  },
			new BoodkingTypeModel { ID=3, Name="Type3"  },
			new BoodkingTypeModel { ID=4, Name="Type4"  },
		};
		public static IEnumerable<CustomerModel> Customers { get; } = new CustomerModel[]
		{
			new CustomerModel { ID=1, Name="Customer1" ,BoodkingType= new int[]{ 1,2,3,4 } },
			new CustomerModel { ID=1, Name="Customer2" ,BoodkingType= new int[]{ 1,2 } },
			new CustomerModel { ID=1, Name="Customer3" ,BoodkingType= new int[]{ 3,4 } },
			new CustomerModel { ID=1, Name="Customer4" ,BoodkingType= new int[]{ 1 } },
		};
	}
