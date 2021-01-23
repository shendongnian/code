    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(conString);
        conn.Open();
        SqlCommand cmd =
            new SqlCommand(
                "SELECT username, pass, isadmin FROM users where username = '" + txtUser.Text + "' and pass='" + txtPass.Text +
                "'", conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        if (dt.Rows.Count > 0)
        {
            Session["id"] = txtUser.Text;
            if (dt.Rows[0]["isadmin"].ToString() == "1")
            {
                Response.Redirect("~/admin.aspx");
            }
            else
            {
                Response.Redirect("~/default.aspx");
            }
            //Response.Redirect("~/default.aspx");
            Session.RemoveAll();
        }
        else
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            //lblMsg.Text= msg ;
            //Response.Write("<script>alert('Please enter valid Username and Password')</script>");
        }
    }
