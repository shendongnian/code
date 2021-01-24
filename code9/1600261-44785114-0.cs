    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(Request.HttpMethod.ToString() + "<br/>");
        if (Request.HttpMethod == "POST")
        {
            if (Request.Form.Count > 0)
            {
                Response.Write(Request.Form[0] +"<br/>");
                Response.Write(Request.Form[1] + "<br/>");
                Response.Write(Request.Form[2] + "<br/>");
            }
        }
    }
