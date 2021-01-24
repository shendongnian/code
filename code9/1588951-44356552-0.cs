    var table = new DataTable();
    table.Columns.Add("AttributeID", typeof(int));
    table.Columns.Add("Level", typeof(int));
    		
    //Add data
    table.Rows.Add(new []{1, 2});
    
    //More code
    Command.Parameters.AddWithValue("@Attributes", table);
