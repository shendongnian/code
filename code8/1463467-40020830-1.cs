    DataTable dt4 = new DataTable();
    
    sda4.Fill(dt4);
    if (dt4.Rows.Count > 0)
    {
    	GridView3.DataSource = dt4;
    	GridView3.DataBind();
    }
    else
    {
    	Label1.Visible = true;
    }
