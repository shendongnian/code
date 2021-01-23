	public static class HttpUrlEncode
	{
		public static FormUrlEncodedContent Encode(Object obj)
		{
			if (obj == null)
				throw new ArgumentNullException("obj");
				
			var props = obj
				.GetType()
				.GetProperties(BindingFlags.Instance | BindingFlags.Public)
				.ToDictionary(
					prop => 
						prop.Name,
					prop => 
						(prop.GetValue(someObject, null) ?? String.Empty).ToString());
						
			return new FormUrlEncodedContent(props);
		}
	}
	var dataParams = HttpUrlEncode.Encode(
		new 
		{
			name = "myname",
			id = 2
		});       
