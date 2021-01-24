    //create a datatable
    DataTable table = new DataTable();
    
    //auto increment column
    DataColumn column = new DataColumn("id", typeof(int));
    column.AutoIncrement = true;
    column.AutoIncrementSeed = 1;
    column.AutoIncrementStep = 1;
    table.Columns.Add(column);
    
    //add a normal column
    column = new DataColumn("value", typeof(string));
    table.Columns.Add(column);
    
    //add some data to the table
    table.Rows.Add(null, "Netherlands");
    table.Rows.Add(null, "Japan");
    table.Rows.Add(99, "Australia");
    table.Rows.Add(null, "America");
