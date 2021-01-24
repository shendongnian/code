    //Remove initialization logic from page load.
    protected void Page_Load(object sender, EventArgs e)
    {
    	((Default)Page).Log += "GRANDCHILD CONTROL PAGE LOAD\n";
    }
    
    //This method has been added to be called from the ItemDataBound event.
    public void InitializeControls()
    {
    	ddlAgeGroup.Items.Insert(0, new ListItem() { Text = "SELECT AN AGE GROUP", Value = string.Empty });
    
    	if (User != null)
    	{
    		ddlAgeGroup.SelectedValue = User.AgeGroup;
    	}
    }
