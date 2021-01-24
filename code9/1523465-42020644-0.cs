    using(var dbConn = new clsDBConn())
    {
       CMD = new SqlCommand("SELECT * FROM tblEmployee", dbConn.connection);
       SqlDataReader EmplReader = CMD.ExecuteReader();
       while (EmplReader.Read())
       {
          while(DateFrom >= DateTo)
          {
             //Some Reader 
             //Lots of SQL Command ExecuteNonQuery();
          }
       }
    }
