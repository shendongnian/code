	public class First
	{
		public string a { get; set; }
		public string b { get; set; }
		public string d { get; set; }  //Say we need this to sort before 'c'
	}
	public class Second : First
	{
		public string c { get; set; }
	}
	
	...
	var lstSolds = new List<First>();
	for (var i = 0; i < 10; i++)
	{
		lstSolds.Add(new Second
		{
			a = "A-" + i,
			b = "B-" + i,
			c = "C-" + i,
			d = "D-" + i,
		});
	}
	using (var package = new ExcelPackage(file))
	{
		var ws = package.Workbook.Worksheets.Add("table");
		//var mi = typeof(Second)
		//    .GetProperties()
		//    .OrderBy(pi => pi.Name)  //This controls the column order
		//    .Cast<MemberInfo>()
		//    .ToArray();
		var firstmi = typeof (First)
			.GetProperties()
			.OrderBy(pi => pi.Name);
		var secondmi = typeof (Second)
			.GetProperties()
			.Where(pi => !firstmi.Select(fpi => fpi.Name).Contains(pi.Name))
			.OrderBy(pi => pi.Name);
			
		//Sorting above will keep first proper before second
		var mi = firstmi
			.Concat(secondmi)
			.Cast<MemberInfo>()
			.ToArray();
		ws.Cells["A3"]
			.LoadFromCollection(
				lstSolds
				, true
				, TableStyles.Custom
				, BindingFlags.Public | BindingFlags.Instance
				, mi
			);
		package.Save();
	}
