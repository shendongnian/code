    internal static List<User> Create_DataTable(string SQL)
    {
        DataTable dataTable = new DataTable("Work_Orders");
    
        using (DataAccessClass.sql_Connection)
        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SQL, DataAccessClass.sql_Connection))
        {
            DataAccessClass.OpenConnection();
    
            sqlDataAdapter.Fill(dataTable);
        }
         List<User> uList = new List<User>();
         foreach (DataRow row in Datatable.Rows) 
         { 
             uList.Add(new User()
                  { 
                       Name = row["Name"],
                       Family = row["Family"],
                       UserName = row["UserName"]
                   });
          }
        return uList;
    }
