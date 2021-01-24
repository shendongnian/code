    //Try this out...  
      class LG 
        {
            Connection MainConnection = new Connection();
            public static string _password;
            public static string _username;
            string username;
            string password;
        
            public LG (string username, string password)
            { 
                this.username = username;
                this.password = password;
            }
        
            public void add()
            {
                string query = "insert into LG (Username,[Password])values('" +                                  
                 username + "','" + password+ "')";
                OleDbCommand com = new OleDbCommand(query,  
               MainConnection.getConnect());
               com.ExecuteNonQuery();
              //close connection here
               MainConnection.Dispose();
             }
