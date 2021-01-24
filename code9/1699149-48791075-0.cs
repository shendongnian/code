    DataTable table = new DataTable("Info");
    table.Columns.Add(new DataColumn("index", typeof(Int32)));
    table.Columns.Add(new DataColumn("data", typeof(String)));
    for (Int32 i = 0; i < myList.Length; i++)
    {
        DataRow row = symbolsTable.NewRow();
        row[0] = i;
        row[1] = myList[i];
        table.Rows.Add(row);
    }
    this.myDgrv.DataSource = table;
