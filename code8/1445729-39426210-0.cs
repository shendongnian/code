	var lines = xeCoord.Value.Trim()
        .Split(new string[] {",0"}, StringSplitOptions.RemoveEmptyEntries)
		.Select(x=> 
			{	
				int i=0;
				var splits = x.Split(new string[] {","},StringSplitOptions.RemoveEmptyEntries)       
					.GroupBy(g=> i++/2)                       //Group for consecutive values to form a coordinate.
					.Select(s=>string.Join(",",s))            // Join them
                    .ToList();					
				splits.Insert(0,splits.Count().ToString());   // Insert the count at the beginning
				return splits;
					
			})
			.SelectMany(x=>x);                                // flatten the structure
 
     // now write these lines to file.
     File.AppendAllLines(@"C:\New folder\longlat.txt", lines);  
