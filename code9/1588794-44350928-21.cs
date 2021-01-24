	public class MyCustomJsonSerializerSettings // not a static class
	{
		private static JsonSerializerSettings _jss;
		
		public static JsonSerializerSettings Jss
		{
			get { return _jss; }
			private set { _jss = value; }
		}
		
		static MyCustomJsonSerializerSettings()
		{
			_jss = new JsonSerializerSettings { ... };
		}
		private class FooToBarConverter : JsonConverter // note that it is contained within
                                                        // the class
		{
            ...
		}
	}
