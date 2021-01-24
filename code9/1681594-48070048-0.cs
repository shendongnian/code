	var lstSolds = new List<First>();
	for (var i = 0; i < 10; i++)
	{
		lstSolds.Add(new Second
		{
			a = "A-" + i,
			b = "B-" + i,
			c = "C-" + i
		});
	}
	using (ExcelPackage package = new ExcelPackage(archivo)) 
	{
		var mi = typeof (Second)
			.GetProperties()
			.OrderBy(pi => pi.Name)  //This controls the column order
			.Cast<MemberInfo>()
			.ToArray();
			ws.Cells["A3"]
				.LoadFromCollection(
					lstSolds
					, true
					, TableStyles.Custom
					, BindingFlags.Default
					, mi
				);
			
		package.Save();
	}
