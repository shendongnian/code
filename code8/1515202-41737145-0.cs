    protected void btnLogin_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        using(SqlConnection conn = new SqlConnection(conString))
        {
            using(SqlCommand cmd = new SqlCommand("SELECT username, pass, isadmin FROM users where username = @UserName and pass=@Pass", conn))
            {
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtUser.Text;
                cmd.Parameters.Add("@Pass", SqlDbType.VarChar).Value = txtPass.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }   
        
        }
        if (dt.Rows.Count > 0)
        {
            Session["id"] = txtUser.Text;
            if (dt1.Rows[0]["isadmin"].ToString() == "1")
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
