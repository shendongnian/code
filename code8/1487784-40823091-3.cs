    try
    {
        StringBuilder sb = new StringBuilder();
        //use sb to build the SQL string query
    
       using (SqlConnection conn = CreateSqlConnection(connString))
        {
           using (SqlCommand command = CreateSqlCommand(sb.ToString(), conn)
           {
               //open connection + execute command 
           }
        }
    
    {
    catch(Exception ex) 
    {
    }
