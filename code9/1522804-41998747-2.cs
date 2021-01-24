	public static class Check
	{
		public static string Result1 { get; set; }
		public static string Result2 { get; set; }
		
		public static void MyValue(string qr)
		{
			Result1 = "My Name" + qr;
		    Result2 = "You're" + qr;
		}	
	}
