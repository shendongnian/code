    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["EnabledAmtPaidTextBoxes"] = new Dictionary<int, bool>();
            GetCustomer();
        }
    }
