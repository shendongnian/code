    //Registration
    using (SqlConnection Conn=new SqlConnection(CS))
    {
        SqlCommand cmd = new SqlCommand("sp_RegisterUser",Conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter UserName = new SqlParameter("@UserName",txtUserName.Text);
        string Salt = string.Empty;
        string Password = SecurityHelper.GeneratePasswordHash(txtPassword.Text, SecurityHelper.DefaultIterations, out salt);
        ;
        SqlParameter Password = new SqlParameter("@Password", Password);
        SqlParameter Email = new SqlParameter("@Email", txtEmail.Text);
        SqlParameter Salt = new SqlParameter("@Salt", Salt);
        cmd.Parameters.Add(UserName);
        cmd.Parameters.Add(Password);
        cmd.Parameters.Add(Email);
        Conn.Open();
        int ReturnCode=(int) cmd.ExecuteScalar();
        if (ReturnCode==-1)
        {
            lblMessage.Text = "User Name alredy exists";
        }
        else
        {
             Response.Redirect("~/Login.aspx");
        }
    }
   
    //Log In
    private bool AuthenticateUser(string username, string password)
    {
        //Get the following from your database based on username
        string savedHash = //fromDB;
        string savedSalt = //fromDb;
        
        return (SecurityHelper.GetPasswordHash(password, savedSalt, SecurityHelper.DefaultIterations) == tempUser.Password)                
    }
