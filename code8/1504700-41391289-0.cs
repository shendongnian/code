    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    
    User user;
    using (IDbConnection cnn = new SqlConnection(cs))
    {
        user = cnn.Query<User>(
            "Select UserName, Password from tbl_Login where UserName=@username and Password=@password",
            new { username = txt_UserName.Text, password = txt_Password.Text })
            .SingleOrDefault();
    }
    
    if (user != null)
    {
        // Do someting
    }
