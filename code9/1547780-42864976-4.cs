    ..
    using System.Data.SqlClient;
    ..
    string a = YourTableName;        
    using (SqlConnection sqlCon = new SqlConnection(YourDatabaseConnection))
    {
     sqlCon.Open()
    using (SqlCommand sqlCmd = sqlCon.CreateCommand())
    {
    sqlCmd.CommandText = "auto_delete";
    sqlCmd.CommandType = CommandType.StoredProcedure;
    sqlCmd.Parameters.Add(new SqlParameter("NewTableName", a));
    sqlCmd.ExecuteNonQuery();
    }   
     sqlCon.Close();
     }
