    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.PopulateHobbies();
        }
    }
