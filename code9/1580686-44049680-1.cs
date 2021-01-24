       private static string ConnectionString {
         get {
           //TODO: do not hardcode. move it to settings
           return @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Project\KEBMS\KEBMS\MainDatabase.mdf;Integrated Security=True;Connect Timeout=30";
         }
       }
    
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
                WHERE [Username] = @prm_UserName and -- password is a keyword
                      [Password] = @prm_Password";
    
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
    
       private void btnexit_Click(object sender, EventArgs e) {
         if (TryLogin(txtusername.Text, txtpassword.Text)) {
           frmHome Home = new frmHome();
           Home.Show();
           this.Hide();
         }
         else { 
           MessageBox.Show("Wrong Username or/and Password");
           txtusername.Clear();
           txtpassword.Clear();
    
           if (txtusername.CanFocus) 
             txtusername.Focus();  
         }
       }
