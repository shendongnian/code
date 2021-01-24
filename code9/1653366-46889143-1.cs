    _insertCmd["@name"].Value=txtName.Text;
    ...
    using(var connection = new SqlConnection(_connectionString))
    {
          _insertCmd.Connection=connection;  
          connection.Open();
          _insertCmd.ExecuteNonQuery(); 
    }
