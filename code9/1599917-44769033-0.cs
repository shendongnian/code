    using System.Data.Linq;
    ......
    ......
    // Merge both tables data and group them by comparing columns values
	dt1.Merge(dt2);	
	var g = dt1.AsEnumerable()
			.GroupBy(x => x[0]?.ToString() + x[1]?.ToString()) // You can build Unique key here, I used string concatination
			.ToDictionary(x => x.Key, y => y.ToList());
	
	var unique = dt1.Clone();
	
	foreach (var e in g)
	{
		if (e.Value.Count() == 1) // In either table - Intersaction 
		{
			e.Value.CopyToDataTable(unique, LoadOption.OverwriteChanges);
		}
		if (e.Value.Count() == 2) 
		{
			// In both tables -Union
		}
	}
