    SqlDataReader reader= command.ExecuteReader();
    using (var schemaTable = reader.GetSchemaTable())
        {
            foreach (DataRow row in schemaTable.Rows)
            {
                string ColumnName= row.Field<string>("ColumnName");
                string DataTypeName= row.Field<string>("DataTypeName");
                short NumericPrecision= row.Field<short>("NumericPrecision");
                short NumericScale= row.Field<short>("NumericScale");
                int ColumnSize= row.Field<int>("ColumnSize");
                Console.WriteLine("Column: {0} Type: {1} Precision: {2} Scale: {3} ColumnSize {4}",      
                ColumnName, DataTypeName, NumericPrecision, scale,ColumnSize);
            }
        }
