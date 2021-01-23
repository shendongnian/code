    try
    {
        StringBuilder sb = new StringBuilder();
        //use sb not StreamReader to build the SQL string query
    
       using (SqlConnection conn = CreateSqlConnection(connString))
        {
           using (SqlCommand command = CreateSqlCommand(s, conn)
           {
               //open connection + execute command 
           }
        }
    
    {
    catch(Exception ex) 
    {
    }
