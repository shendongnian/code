    string strcon = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    
    using(SqlConnection dbConnection = new SqlConnection(strcon))
        {
          if (dbConnection.State==ConnectionState.Closed)
          {                      
              con.Open();   
          }
        }
