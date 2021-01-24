    using (DbConnection)
            {
                DbConnection.Open();
                using (OdbcCommand DbCommand = DbConnection.CreateCommand())
                {
                    DbCommand.CommandType = CommandType.StoredProcedure;
                    DbCommand.CommandText = " GetOrdersEmailContent";
    
                    DbCommand.Parameters.Add("@Name", OdbcType.NVarChar, 50);
                    DbCommand.Parameters["@Name"].Value = templateName;
    
                    DbCommand.Parameters.Add("@Body", OdbcType.NVarChar, 2000);
                    DbCommand.Parameters["@Body"].Value = DBNull.Value;
                    DbCommand.Parameters["@Body"].Direction = ParameterDirection.Output;
    
                    DbCommand.ExecuteNonQuery();
    
                    emailBody = DbCommand.Parameters["@Body"].Value.ToString();   
                }
            }
            DbConnection.Close();
