    using(var dbConn = new clsDBConn())
    {
       using(var CMD = new SqlCommand("SELECT * FROM tblEmployee", dbConn.connection))
       {
          using(SqlDataReader EmplReader = CMD.ExecuteReader())
          {
             while (EmplReader.Read())
             {
                while(DateFrom >= DateTo)
                {
                //Some Reader 
                //Lots of SQL Command ExecuteNonQuery();
                }
             }
          }
       }
    }
