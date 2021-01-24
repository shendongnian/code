    using (SqlConnection conn = new SqlConnection(@"Data source = 2c4138928627\Sage ; Database=ARMINDOData ; User Id=sa ; Password=sage2008+"))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
    
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "USP_InsertFile";
    
                    command.Parameters.AddWithValue("@fileName",fileName);
                    command.Parameters.AddWithValue("@fileContent",fileContent);
    
                    command.ExecuteNonQuery();
                }
