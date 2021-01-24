	namespace MyProject 
	{
		public class MyViewModel
		{
			public int ID { get; set; }
			public System_Tracking Tracking { get; set; }
			public Report_Login_Credentials Credentials { get; set; }
			public Report_Type Type { get; set; }
            public List<Report_Peramiter_Fields> Fields { get; set; }
			public string Name { get; set; }
			public string Location { get; set; }
		}
	}
