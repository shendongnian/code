    protected void Button1_Click(object sender, EventArgs e)
    {
        string url;
        url = "backend.aspx?name=" + Server.UrlEncode(TextBox1.Text);
        Response.Redirect(url);
    }
    protected void Page_Load(object sender, EventArgs e)
     {
         Label1.Text = Request.Params["name"];
     }
