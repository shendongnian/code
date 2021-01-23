            from table in connection.GetSchema("Tables").AsEnumerable()
            let name = (string)table["TABLE_NAME"]
            let catalog = (string)table["TABLE_CATALOG"]
            let schema = (string)table["TABLE_SCHEMA"]
            select new Tables // this should really be called Table
            {
                Name = name,
                Columns = selectedTables.Contains(name) ? (
                    from column in connection.GetSchema("Columns", new [] { catalog, schema, name }).AsEnumerable()
                    select (string)column["COLUMN_NAME"]).ToArray() : null
            }).ToList();
 
