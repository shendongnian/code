    // DataTable dt = new DataTable(); for (int i = 1; i < 6; i++) dt.Columns.Add("Col" + i); 
    // foreach (var c in "EEFG") dt.Rows.Add(("A B C D " + c).Split());   // optional to generate the table
	dt = dt.Rows.Cast<DataRow>()
	    .GroupBy(r => Tuple.Create(r[0], r[1], r[2], r[3]))          // group by the first 4 values in each row (you can replace the numbers with the indexes or names of your columns)
	    .SelectMany(g => g.GroupBy(r => r[4], (k, v) => v.First()))  //  group each group by the 5th value, and select the first row in each group, to get the distinct rows
        .CopyToDataTable();                                          // optional to copy the rows to a new DataTable
    Debug.Print(string.Join("\n", dt.AsEnumerable().Select(r => string.Join("\t", r.ItemArray)))); // optional to print the result
