    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            SiteUser s = null;
            try
            {
                string email = txtEmail.Text;
                string pwd = txtPwd.Text;
                s = DBConnection.login(email, pwd);                
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                lblLoginError.Text = "Error logging in.";
            }
            if (s != null)
            {
                Session["UserSession"] = s;
                Response.Redirect("~/UI/Home.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                lblLoginError.Text = "User not found. Please check your details and try again.";
            }
        }
        catch(System.Threading.ThreadAbortException)
        {
            //Do nothing.  The exception will get rethrown by the framework when this block terminates.
        }
    }
