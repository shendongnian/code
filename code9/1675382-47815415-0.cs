    public static bool IsAnyNullOrEmpty(object objectToBeChecked, params string[] parametersToBeChecked)
	{
		foreach (var obj in (IEnumerable)objectToBeChecked)
		{
			foreach (var pi in obj.GetType().GetProperties())
			{
				if (parametersToBeChecked.Contains(pi.Name))
				{
					var value = (string)pi.GetValue(obj);
					if (string.IsNullOrEmpty(value))
					{
						return true;
					}
				}
			}
		}
		
		return false;
	}
