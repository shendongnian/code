    var table = new DataTable();
    table.Columns.Add("name");
    table.Columns.Add("code");
    table.Columns.Add("price");
    foreach (var item in items)
    {
      table.Rows.Add(item);
    }
