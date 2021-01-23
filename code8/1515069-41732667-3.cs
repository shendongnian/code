	namespace System
	{
		public static class ObjectExtension
		{
			public static string Extend(this object input)
			{
				// Do something to input object.
				// For example, you can have different implementation based on its type.
				if (input is string)
				{
				}
				else if (input is bool)
				{
				}
			}
		}
	}
	
