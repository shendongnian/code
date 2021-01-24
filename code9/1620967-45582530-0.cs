	public static IEnumerable<T> ValidateStringData<T>(this IEnumerable<T> dataList)
	{
		var properties = typeof(T).GetProperties().Where(p => p.PropertyType == typeof(string)).ToArray();
		foreach (var item in dataList)
		{
			foreach (var propertyInfo in properties)
			{
				var value = propertyInfo.GetValue(item, null) as string;
				string newValue;
				if (CheckString(value, out newValue))
				{
					propertyInfo.SetValue(item, newValue, null);
				}
			}
			yield return item;
		}
	}
	
    private static bool CheckString(string value, out string newValue)
	{
		// do your validation logic here.
	}
