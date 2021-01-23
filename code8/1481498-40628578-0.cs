    var dataTable = new DataTable();
    dataTable.Columns.Add("ID", typeof(int));
    dataTable.Columns.Add("CategoryID", typeof(int));
    dataTable.Columns.Add("Category", typeof(string));
    dataTable.Rows.Add(1, 1, "Category1");
    dataTable.Rows.Add(2, 1, "Category2");
    dataTable.Rows.Add(3, 2, "Category3");
    dataTable.Rows.Add(4, 2, "Category4");
    dataTable.Rows.Add(5, 1, "Category5");
    dataTable.Rows.Add(6, 3, "Category6");
    var dict = dataTable.AsEnumerable()
        .GroupBy(row => row.Field<int>("CategoryID"))
        .ToDictionary(
            g => g.Key.ToString(),
            g => g.Select(row => new { Category = row.Field<string>("Category") }).ToList()
        );
    var jss = new JavaScriptSerializer();
    Console.WriteLine(jss.Serialize(dict));
