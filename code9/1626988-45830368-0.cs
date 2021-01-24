    string q = "SELECT **userlevel** FROM user_data WHERE (UserName = '" + txtusername.Text.ToString() + "') AND (Password = '" + passwords + "');";
    SqlCommand cmd = new SqlCommand(q, conn);
    cmd.Parameters.AddWithValue("@Username", this.txtusername.Text.Trim());
    cmd.Parameters.AddWithValue("@Password", this.txtpassword.Text.Trim());
    object obj = cmd.ExecuteScalar();
    if(obj != null)
    {
         if((int)obj == 1)
         {
            Window1 wnd = new Window1();
            wnd.Open();
         }
         else
         {
            Window2 wnd = new Window2();
            wnd.Open();
         }
    }
    else
    {
       // kick
    }
