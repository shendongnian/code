    var tbl = new DataTable("Sample");
    tbl.Columns.Add("Column1", typeof(int));
    tbl.Columns.Add("Column2", typeof(int));
    tbl.Columns.Add("Column3", typeof(int));
    tbl.Columns.Add("Category", typeof(int)); // foreign-key to category table
