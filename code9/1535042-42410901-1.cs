     SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
            try {
                conn.Open();
                string checkUser = "Select count(*) from Registeration where UserName =  @username  and Password = @pass";
                SqlCommand sq = new SqlCommand(checkUser, conn);
                sq.Parameters.AddWithValue("@username", TextBoxUserName.Text);
                sq.Parameters.AddWithValue("@pass", TextBoxPassword.Text);
                SqlDataAdapter da = new SqlDataAdapter(sq);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0) {
                    Response.Redirect("default.aspx");
                } else {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
                }
            } finally {
                conn.Close();
            }
