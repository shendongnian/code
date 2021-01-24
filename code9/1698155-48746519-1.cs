    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
           GenerateTrueFalseListItems(EnableDatabaseTask);
           //and more radiobutton lists
           //GenerateTrueFalseListItems(Name_Of_Your_RadioButtonList);
        }
    }
