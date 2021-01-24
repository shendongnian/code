    protected void Page_Load(object sender, EventArgs e)
    {
    	ListView1.DataSource = new List<dynamic>() {
    		new { Name = "Andy", Position = "PG"},
    		new { Name = "Bill", Position = "SD"},
    		new { Name = "Caroline", Position = "Manager"}
    	};
    	ListView1.DataBind();
    }
