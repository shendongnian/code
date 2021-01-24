    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var param = Request.QueryString["datetime"];
            if (DateTime.TryParse(param, out DateTime result))
            {
                if (DateTime.Now > result)
                {
                    Response.Redirect("wherever");
                }
            }
        }
    }
