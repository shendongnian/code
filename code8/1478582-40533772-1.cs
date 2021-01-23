    using(SqlConnection connection = new SqlConnection(connString)){
    connection.Open();
    bool userNameExists = false;
    
    var command = 
    new SqlCommand("SELECT COUNT(*) FROM Signin WHERE UserName = @UserName", connection);
    command.Parameters.AddWithValue("@UserName",UserNameBox.Text.Trim();
    userNameExists = (int)command.ExecuteScalar() > 0;
    //if exists
    if(userNameExists) {
    UserExists.Text = "User Already Exists";
    }else{
    command = new SqlCommand("SigningIn", connection);
    command.CommandType = CommandType.StoredProcedure;
    command.Parameters.AddWithValue("@UserName", UserNameBox.Text);
    command.Parameters.AddWithValue("@Password", PasswordBox.Text);
    command.ExecuteNonQuery();
    connection.Close();
    }
