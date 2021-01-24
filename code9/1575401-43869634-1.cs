    protected void Page_Load(object sender, EventArgs e)
    {
    	repeater.DataSource = new[] {
    		new {Id= 1, Text = "Text 1"  },
    		new {Id= 2, Text = "Text 2"  },
    	};
    	repeater.DataBind();
    }
    
    protected void repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
    	if (e.CommandName == "Delete")
    	{
    		Response.Write($"Do something with {e.CommandArgument}");
    	}
    
    }
