	public static Check MyValue(string qr)
	{
		var result = new Check();
		result.Result1 = "My Name" + qr;
		result.Result2 = "You're" + qr;
		return result;
	}
	
