    string[] selectedTables = { "Table1", "Table2"};
    using (var conection = new SqlConnection("MyconnectionString"))
    {
        connection.Open();
        var tables = (
            from table in connection.GetSchema("Tables").AsEnumerable()
            let name = (string)table["TABLE_NAME"]
            where selectedTables.Contains(name)
            let catalog = (string)table["TABLE_CATALOG"]
            let schema = (string)table["TABLE_SCHEMA"]
            select new Tables // this should really be called Table
            {
                Name = name,
                Columns = (
                    from column in connection.GetSchema("Columns", new [] { catalog, schema, name }).AsEnumerable()
                    select (string)column["COLUMN_NAME"]).ToArray()
            }).ToList();
        return tables;
    }
