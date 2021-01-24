    using(OleDbConnection excel_con = new OleDbConnection(connectionString))
    using(OleDbCommand cmd = new OleDbCommand())
    {
        excel_con.Open();
        DataTable result = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        var names = result.AsEnumerable().Select(x => x.Field<string>("TABLE_NAME").TrimEnd('$')).ToList();
        comboBoxTables.DataSource = names;
    }
