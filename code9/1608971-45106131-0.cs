    public static class extensions
        {
             public async static Task<DataTable> ExecuteAndCreateDataTableAsync(this SqlCommand cmd)
             {
                 using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                 {
                     var dataTable = reader.CreateTableSchema();
                     while (await reader.ReadAsync().ConfigureAwait(false))
                     {
                         var dataRow = dataTable.NewRow();
                         for (int i = 0; i < dataTable.Columns.Count; i++)
                         {
                             dataRow[i] = reader[i];
                         }
                         dataTable.Rows.Add(dataRow);
                     }
                     return dataTable;
                     
                 }
             }
             public static void LoadParams(this SqlCommand cmd, params SqlParameter[] parameters)
             {
                 if (parameters != null)
                 {
                     foreach (var parameter in parameters)
                     {
                         if (parameter != null)
                         {
                             if (parameter.Value == null)
                                 parameter.Value = DBNull.Value;
    
                             cmd.Parameters.Add(parameter);
                         }
                     }
                 }
             }
        
    
             private static DataTable CreateTableSchema(this SqlDataReader reader)
             {
                 DataTable schema = reader.GetSchemaTable();
                 DataTable dataTable = new DataTable();
                 if (schema != null)
                 {
                     foreach (DataRow drow in schema.Rows)
                     {
                         string columnName = System.Convert.ToString(drow["ColumnName"]);
                         DataColumn column = new DataColumn(columnName, (Type)(drow["DataType"]));
                         dataTable.Columns.Add(column);
                     }
                 }
                 return dataTable;
             }
        }
