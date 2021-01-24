    DataTable table = new DataTable();
    table.Columns.Add("Id", typeof(int));
    table.Columns.Add("Name", typeof(string));
    table.Rows.Add(1, "");
    table.Rows.Add(2, "b");
    table.Rows.Add(3, "");
    table.Rows.Add(4, "c");
    table.Rows.Add(5, "a");
    table.Rows.Add(6, "");
    table.AsEnumerable().SortByNonEmpty("Name")
