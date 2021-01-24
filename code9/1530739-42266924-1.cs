    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tbTest.Attributes.Add("maxlength", "20");
        }
    }
