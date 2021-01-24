    class Example
	{
		private readonly HashSet<CustomType> _stringCompatibleTypes = new HashSet<CustomType>
		{
			CustomType.Char, CustomType.Fromtotype, CustomType.Nclob, ...
		};
		private readonly HashSet<CustomType> _dateCompatibleTypes = new HashSet<CustomType>
		{
			CustomType.Datetime, CustomType.Timestamp3, CustomType.Timestamp6, ...
		};
		// Another type sets
		public Type Foo(CustomType dataType)
		{
			if (_stringCompatibleTypes.Contains(dataType))
			{
				return typeof(string);
			}
			if (_dateCompatibleTypes.Contains(dataType))
			{
				return typeof(DateTime);
			}
			...
		}
	}
