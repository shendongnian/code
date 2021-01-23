            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT AdminID FROM   [User]  WHERE  StaffEmail = @userName AND StaffPassword =@pwd";
            cmd.Parameters.AddWithValue("@userName", txtUsername.Text);
            cmd.Parameters.AddWithValue("@pwd", txtPassword.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt != null && dt.Rows.Count >0)
            {
                Session["AdminID"] = dt.Rows[0]["AdminID"].ToString();
                Response.Redirect("AppointmentMenu.aspx");
            }
            else
            {
                Response.Write("<script>alert('Please check your Username or Password')</script>");
            }
