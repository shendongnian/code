       //DONE: method extracted
       private bool TryLogin(string login, string password) {
         //DONE: do not use global connections
         //DONE: wrap IDisposable into using
         using (SqlConnection con = new SqlConnection(ConnectionString)) {
           con.Open();
    
           //DONE: Make Sql readable
           //DONE: Make Sql parametrized
           //DONE: Do not expose password - SELECT 1 
           //TODO: Do not store password as a plain text, but its hash      
           string sql = 
             @"SELECT 1 -- we don't want to return any login/password  
                 FROM tblLogin 
                WHERE [Username] = @prm_UserName and 
                      [Password] = @prm_Password -- password is a keyword, wrap it in []";
    
           //DONE: wrap IDisposable into using 
           using (com = new SqlCommand(sql, con)) {
             com.Parameters.AddWithValue("@prm_UserName", login);
             com.Parameters.AddWithValue("@prm_Password", password);  
    
             //DONE: wrap IDisposable into using
             using (var dr = com.ExecuteReader()) {
               return dr.Read(); // do we have at least one record?
             }
           } 
         }
       }
