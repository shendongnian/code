	public static class MyCustomJsonSerializerSettings
	{
		private static JsonSerializerSettings _jss;
		
		public static JsonSerializerSettings Jss
		{
			get { return _jss; }
			private set { _jss = value; }
		}
		
		static MyCustomJsonSerializerSettings()
		{
			_jss = new JsonSerializerSettings
			{
				MissingMemberHandling = MissingMemberHandling.Error,
				NullValueHandling = NullValueHandling.Ignore,
				Converters = new List<JsonConverter>
				{
					new FooToBarConverter()
				}
			};
		}
	}
	
