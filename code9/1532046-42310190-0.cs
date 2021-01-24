        if (TextBox1.Text != string.Empty && TextBox2.Text != string.Empty)
        {
            Connection connec = new Connection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM manager WHERE userName=@userName and password=@password", con);
            cmd.Parameters.AddWithValue("@userName", TextBox1.Text);
            cmd.Parameters.AddWithValue("@password", TextBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                // do something here. (ex: get logs/date/session datas)
            }
            else
            {
                // you have not registered! (Show your warning message here)
                Response.Redirect("register.aspx"); //(or use your popup here)
            }
            con.Close();
            cmd.Dispose();
            Response.Redirect("page.aspx");
        }
        else
        {
            // _userName and _password cannot be null! (your message here)
        }
