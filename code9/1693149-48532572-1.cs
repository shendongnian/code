    protected void Button1_Click(object sender, EventArgs e)
    {
    try
    {
        Guid newGUID = Guid.NewGuid();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand("spCheckUsernameForAnswer", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter parausername = new SqlParameter("@username", TextBoxUN.Text);
        cmd.Parameters.Add(parausername);
        conn.Open();
        var userexsist = (bool)cmd.ExecuteScalar();
        if (userexsist)
        {
            Label1.Text = "Username found";
            conn.close();
        }
        else
        {
            Label1.Text = "not found";
           
            string insertQuery = "insert into [Users] (user_id, first_name, last_name, email, username, password) values (@user_id, @first_name, @last_name, @email, @username, @password)";
            SqlCommand com = new SqlCommand(insertQuery, conn);
            com.Parameters.AddWithValue("@user_id", newGUID.ToString());
            com.Parameters.AddWithValue("@first_name", TextBoxFname.Text);
            com.Parameters.AddWithValue("@last_name", TextBoxLname.Text);
            com.Parameters.AddWithValue("@email", TextBoxEmail.Text);
            com.Parameters.AddWithValue("@username", TextBoxUN.Text);
            com.Parameters.AddWithValue("@password", TextBoxPass.Text);
            com.ExecuteNonQuery();
            Response.Write("Registration successful");
            conn.Close();
        }        
    }
    catch (Exception ex)
    {
        Response.Write("Error:" + ex.ToString());
    }
}
}
