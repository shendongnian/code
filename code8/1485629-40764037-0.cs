    string SQLExpression = "SELECT * FROM SYS.Tables Order By Name";
        
    SqlConnection conn = new SqlConnection(
                  "Data Source=Local;Initial Catalog=myConnection;User ID=sa;Password=12345");
        
    SqlDataAdapter adp = new SqlDataAdapter(SQLExpression, cn);
        
    DataSet ds = new DataSet();
        
    adp.Fill(ds, "SystemData");
