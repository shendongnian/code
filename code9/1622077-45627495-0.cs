    if(firstname.Text.Trim().Lenght>0 && lastname.Text.Trim().Lenght >0 && email.Text.Trim().Lenght>0 && password.Text.Trim().Lenght>0 && dob.Text.Trim().Lenght>0 && phone.Text.Text.Trim().Lenght>0)
    {
    SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "reguser";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@firstname", firstname.Text);
        cmd.Parameters.AddWithValue("@lastname", lastname.Text);
        cmd.Parameters.AddWithValue("@username", email.Text);
        cmd.Parameters.AddWithValue("@password", password.Text);
        cmd.Parameters.AddWithValue("@dob", dob.Text);
        cmd.Parameters.AddWithValue("@phonenumber", phone.Text);
    
        SqlDataAdapter da = new SqlDataAdapter();
        da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
    
        if (dt.Rows.Count > 1)
        {
            Label1.Text = "Registration Sucessfull!!!";
        }
    
        //cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
    else
    {
         //Required fields fill up
    }
