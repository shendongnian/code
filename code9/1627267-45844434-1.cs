	bool HasValue<T>(T obj)
	{
		var type = typeof(T);
		return type.GetProperties().Where(p =>
		{
			var val = p.GetValue(obj);
			if (val is string) return !string.IsNullOrEmpty(val as string);
			return val != null;
		}).Any();
	}
