	var list = new List<Field<string>>();
	list.Add(new FValue<string, int>() { FieldName = null, FieldValue = 5 });
	foreach (var x in list)
	{
		Type[] types = x.GetType().GetGenericArguments();
        // Dirty check to confirm this is an FValue not a Field
		if (types.Length == 2)
		{
			var fieldName = x.FieldName;
			object fieldValue = x.GetType().GetProperty("FieldValue").GetValue(x);
			// fieldValue will be "5"
		}
	}
