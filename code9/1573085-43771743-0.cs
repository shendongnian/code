    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string dt = DateTime.Now.ToString();
        if (Response.Cookies["CurrentLogin"] != null)
        {
            HttpCookie oldLoginCookie = new HttpCookie("LastLogin")
            {
                Expires = Response.Cookies["CurrentLogin"].Expires,
                Value = Response.Cookies["CurrentLogin"].Value
            };
            Response.SetCookie(oldLoginCookie);
        }
        HttpCookie loginCookie = new HttpCookie("CurrentLogin")
        {
            Expires = DateTime.Now.AddDays(365),
            Value = dt.ToString()
        };
        Response.Cookies.Add(loginCookie);
    }
