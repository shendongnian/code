    radGridView1.SelectionChanged += new System.EventHandler(radGridView1_SelectionChanged);
    private void radGridView1_SelectionChanged(object sender, EventArgs e)
    {
    	try
    	{
    		if (this.radGridView1.SelectedRows.Count > 0)
    		{
    			int selectedIndex = radGridView1.SelectedRows[0].Index;
    		}
    	}
    	catch (Exception ex)
    	{
    		Debug.WriteLine(ex.Message);
    	}
    }
