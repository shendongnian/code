    //Setup a DataTable with the same structure as the SQL Type
    var data = new DataTable();
    data.Columns.Add("value", typeof(string));
    //Populate the table
    data.Rows.Add("oneID");
    data.Rows.Add("anotherID");
    //You create your sql command
    cmd.Parameters.Add("@listArgument", data);
    //Command execution
