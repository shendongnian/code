    public void LoginUser()
    {
        string UserNameFromHTML = Page.Request.Form["UserNameIput"];
        string UserPasswordFromHTML = Page.Request.Form["UserPasswordInput"];
        string QueryString = "SELECT User_Id, User_Name, User_Password FROM um_Personnel WHERE User_Name = @UserName and User_Password = @UserPassword";
        SqlCommand Command = new SqlCommand();
        Command.CommandText = QueryString;
        Command.Connection = ConnectionString;
        Command.Parameters.AddWithValue("@UserName", UserNameFromHTML);
        Command.Parameters.AddWithValue("@UserPassword", UserPasswordFromHTML);
        using (SqlDataAdapter Data_Adapter = new SqlDataAdapter(Command))
        {
            DataSet Data_Set = new DataSet();
            Data_Adapter.Fill(Data_Set);
            if (Data_Set.Tables[0].Rows.Count > 0)
            {
                FormsAuthentication.RedirectFromLoginPage(UserNameFromHTML, true); //will return the user to the page who needs a user who is logged in            
            }
            else
            {
                Responce.Redirect("~/Home/Index/");
            }
        }
    }
