    protected void Page_Load(object sender, EventArgs e)
    {
        PopulateMenu();
    }
    
    private void PopulateMenu()
    {
        string role = "B";//You can get the role of logged in user from membeship
        StringBuilder txt = new StringBuilder();
        if (role == "A")
        {
            txt.Append("<li><a href='Sales.aspx'><span>Create</span></a></li>");
        }
        if (role == "B")
        {
            txt.Append("<li><a href='Sales.aspx'><span>View</span></a></li>");
        }
        ul_menu.InnerHtml = txt.ToString();
    }
