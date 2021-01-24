    // DataTable dt = new DataTable(); for (int i = 1; i < 6; i++) dt.Columns.Add("Col" + i); 
    // foreach (var c in "EEFG") dt.Rows.Add(("A B C D " + c).Split());   // optional to generate the table
	dt = dt.Rows.Cast<DataRow>()
	    .GroupBy(r => Tuple.Create(r[0], r[1], r[2], r[3]))  // group by the first 4 values in each row (you can replace the numbers with the indexes or names of your columns)
	    .Select(g => g.GroupBy(r => r[4])                    //  group each group by the 4th column to get the distinct Col5 values
			          .Select(g2 => g2.First()))             //  and get one row from each group to filter out the duplicates
		.Where(g => g.Count() > 1)                           // optional to get only the groups that have more than one distinct row
		.SelectMany(g => g).CopyToDataTable();               // optional to flatten the groups of rows and copy them to a new DataTable
    Debug.Print(string.Join("\n", dt.AsEnumerable().Select(r => string.Join("\t", r.ItemArray)))); // optional to print the result
