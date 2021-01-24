    internal static User Create_DataTable(string SQL)
    {
        DataTable dataTable = new DataTable("Work_Orders");
    
        using (DataAccessClass.sql_Connection)
        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SQL, DataAccessClass.sql_Connection))
        {
            DataAccessClass.OpenConnection();
    
            sqlDataAdapter.Fill(dataTable);
        }
         User u = new User()
           { 
              Name = dataTable.Rows[0]("Name"),
              Family = dataTable.Rows[0]("Family"),
              UserName = dataTable.Rows[0]("UserName")
            }
        return u;
    }
