    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack)
        {
            string myValue = Request.Form["myName"];
        }
    }
