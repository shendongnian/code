        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
        	GridView1.EditIndex = e.NewEditIndex;
        	gridbind(); //Bind gridview
        	TextBox tx_chdets = (TextBox)GridView1.Rows[e.NewEditIndex].FindControl(“TextBox1”);
         if(tx_chdets!=null)
    	{
    		tx_chdets.Readonly=true;
    	}
    
    }
