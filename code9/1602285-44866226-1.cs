    protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList1.DataBind(); // get the data into the list you can set it
                DropDownList1.Items.FindByValue("SOMECREDITPROBLEMS").Selected = true;
            }
        }
