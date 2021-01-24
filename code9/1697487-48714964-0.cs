    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            var db = new dbContext();
            var CustItem = db.customer.ToList();
            customerDropDownList.DataSource = CustItem;
            customerDropDownList.DataTextField = "cust";
            customerDropDownList.DataValueField = "cust";
            customerDropDownList.DataBind();
        }
    }
