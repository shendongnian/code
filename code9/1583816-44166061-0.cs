    lblMsg.Text = ""; 
    
    if (!IsPostBack) 
    { 
    	BindUsers();
        // Set the initial visibility of grids here
    	string desi = Session["Role"].ToString(); 
        
    	if (desi == "Supervisor") 
    	{ 
    		GridView2.Visible = true; 
    		GridView1.Visible = false; 
    		ddlusers.Visible = true; 
    		BtnExport.Visible = false; 
    	} 
    	else 
    	{ 
    		GridView2.Visible = false; 
    		GridView1.Visible = true; 
    		ddlusers.Visible = false; 
    		BtnExport.Visible = false; 
    	}
    } 
