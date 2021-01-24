	var ListName = arrayname.ToList();
	//get number of column, probalby you dont need it
	int cols = ListName.Select(r => r.Length).Max();
	//Create a datasource
	DataTable dt = new DataTable();
	//Write column, probalby you dont need it
	for (int f = 0; f < cols; f++)
		dt.Columns.Add("Col " + (f+1));
	foreach (var row in ListName) {
		//make a row
		List<string> Lrow = new List<string>();
		Lrow.AddRange(row);
		//if row is too short add fields
		if (Lrow.Count < cols)
			for (int i = Lrow.Count; i < dt.Columns.Count; i++) {
				Lrow.Add("");
			}
		//at last add row to dataTable
		dt.Rows.Add(Lrow.ToArray());
	}
    //and set dataGridView's DataSource to DataTable
	dataGridView1.DataSource = dt;
