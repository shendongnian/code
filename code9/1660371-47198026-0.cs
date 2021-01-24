    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!this.IsPostBack)
            ApplyGridFilter(string.Empty);
    }
