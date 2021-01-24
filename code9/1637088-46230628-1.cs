    protected void Page_Load(object sender, EventArgs e)
    {
    	if (DropDownList1.SelectedValue == "WithPosition")
    	{
    		GridView1.DataSource = new List<dynamic>() {
    			new { Name = "Andy", LastName="Wayne", Position = "PG"},
    			new { Name = "Bill", LastName="Johnson", Position = "SD" },
    			new { Name = "Caroline", LastName="Barry", Position = "Manager"}
    		};
    		GridView1.DataBind();
    	}
    	else if (DropDownList1.SelectedValue == "NameOnly")
    	{
    		GridView1.DataSource = new List<dynamic>() {
    			new { Name = "Andy", LastName = "Wayne"},
    			new { Name = "Bill", LastName = "Johnson"},
    			new { Name = "Caroline", LastName = "Barry"}
    		};
    		GridView1.DataBind();
    	}
    }
