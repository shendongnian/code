    var table = new DataTable();
    table.Columns.Add(new DataColumn("Id"));
    table.Columns.Add(new DataColumn("Name"));
    table.Rows.Add(new object[] { 123, "Name1" });
    table.Rows.Add(new object[] { 234, "Name2"});
    table.Rows.Add(new object[] { null, "Name3" });
    
    var view = new DataView(table);
    view.RowFilter = "Id is null";
    
    for (int i = 0; i < view.Count; i++)
       Console.WriteLine(view[i][1].ToString());
    
    Console.ReadLine();
