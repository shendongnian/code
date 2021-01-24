	public List<T> CombinationsOf<T>(T template)
	{
		var properties = typeof(T).GetProperties().Where(prop => prop.CanRead && prop.CanWrite).ToArray();
		var combinations = 1 << properties.Length;
		var result = new List<T>(combinations - 1);
		for (var i = 1; i < combinations; i++)
		{
			var instance = (T)Activator.CreateInstance(typeof(T));
			var bits = i;
			for (var p = 0; p < properties.Length; p++)
			{
				properties[p].SetValue(instance, (bits % 2 == 1) ? properties[p].GetValue(template) : Activator.CreateInstance(properties[p].PropertyType));
				bits = bits >> 1;
			}
			
			result.Add(instance);
	    }
		
		return result;
	}
