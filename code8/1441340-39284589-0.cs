    DataTable dt = new DataTable();
     
    //Add columns to DataTable.
    dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("Name"), new DataColumn("Country") });
     
    //Set the Primary Key Column.
    dt.PrimaryKey = new DataColumn[] { dt.Columns["Id"] };
     
    //Add rows to DataTable.
    dt.Rows.Add(1, "John Hammond", "United States");
    dt.Rows.Add(2, "Mudassar Khan", "India");
    dt.Rows.Add(3, "Suzanne Mathews", "France");
    dt.Rows.Add(4, "Robert Schidner", "Russia");
