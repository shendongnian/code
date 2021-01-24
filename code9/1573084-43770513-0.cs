    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if(Request.Cookies["LastLogin"] != null)
        {
             Request.Cookies["PrevLogin"].Value = Request.Cookies["LastLogin"].Value;
             Request.Cookies["PrevLogin"].Expires = DateTime.Now.AddDays(365);
        }
        string dt = DateTime.Now.ToString();
        Response.Cookies["LastLogin"].Value = dt.ToString();
        Response.Cookies["LastLogin"].Expires = DateTime.Now.AddDays(365);
    }
