	dr.Read();
	for (var i = 1; i < dr.FieldCount; i++)
	{
	    if (dr.GetFieldValue<int>(i) == 1)
	    {
	        rolelist.Add(dr.GetName(i));
	    }
	}
