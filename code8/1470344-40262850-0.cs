        SqlDataReader dataReader = command.ExecuteReader();
        if (!dataReader.HasRows || !withValues)
        {
            DataTable dt = dataReader.GetSchemaTable();
            foreach(DataRow row in dt.Rows)
            {
                Console.WriteLine("ColumnName: " + row.Field<string>("ColumnName"));
                Console.WriteLine("NET Type: " + row.Field<string>("DataTypeName"));
                Console.WriteLine("Size: " + row.Field<int>("ColumnSize"));
            }
       }
