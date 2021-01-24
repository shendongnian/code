    public void _loginFrmSubmit(object sender, EventArgs e)
    {
                Session["User"] = home_username.Text;
                if (remember.Checked)
                    Session.Timeout = 464800;
                else
                    Session.Timeout = 120;
                Response.Redirect(Request.RawUrl);
                Response.Redirect(Request.RawUrl);
    }
