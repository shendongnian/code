    for (int i = 0; i < dt1.Rows.Count; i++)
	{
		if (dt1.Rows[i]["RowNum"] != dt2.AsEnumerable().Where(x => x.Field<int>("RowNum") == i))
		{
			...
		}
		else {
		...
		}
		
	}
