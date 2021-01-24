    var ut = Nullable.GetUnderlyingType(objProperty.PropertyType);
	if (ut != null)
	{
		value = row[columnname].ToString().Replace("$", "").Replace(",", "");
		objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(ut.ToString())), null);
	}
	else
	{
		value = row[columnname].ToString().Replace("%", "");
		objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
	}
