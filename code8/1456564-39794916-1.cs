            string sqlStatement = "UPDATE dbo.Fair_Use_InScope_MIF_Alex_temp SET in_scope = 0, modified_by = @modifiedBy, date_updated = @updateDate WHERE (id = @rowToUpdate)";
            
            using (SqlConnection connection = new SqlConnection(cs))
            using (SqlCommand command = new SqlCommand(sqlStatement, connection))
            {
                command.Parameters.Add("@modifiedBy", SqlDbType.VarChar).Value = modifiedBy;
                command.Parameters.Add("@updateDate", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@rowToUpdate", SqlDbType.Int).Value = 35;
                connection.Open();
                command.ExecuteNonQuery();
            } 
