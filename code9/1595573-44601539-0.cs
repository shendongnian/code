     protected void Button1_Click(object sender, EventArgs e)
            {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE email=@useremail and password=@password", con);
                    cmd.Parameters.Add("@useremail", SqlDbType.Text).Value = emailtext.Text;
                    cmd.Parameters.Add("@password", SqlDbType.Text).Value = passwordtext.Text;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
    
                    if (dt.Rows.Count > 0)
                    {
                        Response.Redirect("Membermenu.aspx");
                    }
                    else
                    {
                        lblMsg.Text = "Your username and password is incorrect";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        emailtext.Text = "";
                        passwordtext.Text = "";
                    }
            }
