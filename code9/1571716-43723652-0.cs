	public static Large CreateLargeFromSmalls(int id, IEnumerable<Small> smalls)
	{
		var largeType = typeof(Large);
		var large = new Large { Id = id };
	
		foreach (var small in smalls)
		{
			var prop = largeType.GetProperty(small.Name);
			if (prop != null)
			{
				prop.SetValue(large, small.Value);
			}
		}
	
		return large;
	}
