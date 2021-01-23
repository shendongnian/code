    using (SqlCommand command = new SqlCommand(sSql, con))
    {
         using (SqlDataReader reader = command.ExecuteReader())
         {
              while (reader.Read())
              {     
                   DataTable dtSchema = reader.GetSchemaTable();
                   for (int i = 0; i < reader.FieldCount; i++)
                   {
                       var fieldVal = reader.GetValue(i).ToString();
                   }
              }
         }
    }
