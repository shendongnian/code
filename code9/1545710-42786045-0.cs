    private void UpdateStaff()
    {
        string query = "UPDATE Staff SET firstname = @firstname, lastname = @lastname, username = @username, admin = 0";
    
        SqlParameter[] parameters = new SqlParameter[3];
        parameters[0] = new SqlParameter("@firstname", SqlDbType.Varchar).Value = @firstname;
        parameters[1] = new SqlParameter("@lastname", SqlDbType.Varchar).Value = @lastname;
        parameters[2] = new SqlParameter("@username", SqlDbType.Varchar).Value = @username;
    
        ExecuteNonQuery(query, parameters);
    }
            
            
    private void ExecuteNonQuery(string query, SqlParameter[] parametros)
    {
        var conn = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + Database + ";User Id=" + Username + ";Password=" + Password + ";");
        try
        {
            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
    
            foreach (SqlParameter p in parametros)
            {
                command.Parameters.Add(p);
            }
    
            command.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            conn.Dispose();
            conn.Close();
        }
    }
