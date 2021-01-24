    var dt = new DataTable();
    dt.Columns.Add("IdColumn", typeof(int));
    for (int i = 0; i < 10; i++)
    {
        dt.Rows.Add(new object[] { i } );
    }
    var del = 3;
    dt = dt.AsEnumerable().Skip(del).CopyToDataTable();
