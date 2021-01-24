	public static int? AsInt32(this IDataReader rdr, int index)
	{
		Type ft = rdr.GetFieldType(index);
		if (ft == typeof(int))
			return rdr.GetInt32(index);
		else if (ft == typeof(string))
		{
			int v;
			if (Int32.TryParse(rdr.GetString(index), out v))
				return v;
		}
		else if (ft == typeof(object))
		{
			object fv = rdr.GetValue(index);
			int? v = fv as int?;
			if (v != null)
				return v.Value;
		}
		
		return null;
	}
