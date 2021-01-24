    try
    {
    	navBarControl1.BeginUpdate();
    
    	//GET GROUP
    	if (koneksidb.con.State == ConnectionState.Open)
    		koneksidb.con.Close();
    	koneksidb.con.Open();
    	OracleCommand cmd = new OracleCommand();
    	cmd.CommandText = @"SELECT DISTINCT GROUPMENU FROM MENU ";
    	cmd.Connection = koneksidb.con;
    	OracleDataReader dr = cmd.ExecuteReader();
    	while (dr.Read())
    	{
    		List<string> header = new List<string>();
    		header.Add(dr["GROUPMENU"].ToString());
    
    		foreach (string hdr in header)
    		{
    			NavBarGroup group = new NavBarGroup(hdr);
    			//group.Caption = fi.Name;
    			group.LargeImageIndex = 0;
    			group.Expanded = true;
    
    			//GET ITEM
    			OracleCommand cmd1 = new OracleCommand();
    			cmd1.CommandText = @"SELECT * FROM MENU WHERE GROUPMENU='" + hdr + "' ORDER BY GROUPMENU ASC";
    			cmd1.Connection = koneksidb.con;
    			OracleDataReader dr1 = cmd1.ExecuteReader();
    			while (dr1.Read())
    			{
    				List<string> JudulLists = new List<string>();
    				JudulLists.Add(dr1["JUDULMENU"].ToString());
    
    				foreach (var Judul in JudulLists)
    				{
    					NavBarItem item = new NavBarItem(Judul.ToString());
    					navBarControl1.Items.Add(item);
    					group.ItemLinks.Add(item);
    				}
    			}
    
    			if (group.ItemLinks.Count > 0)
    			{
    				navBarControl1.Groups.Add(group);
    			}
    		}
    	}
    }
    catch (Exception ex)
    {
    	MessageBox.Show(ex.Message);
    }
    finally
    {
    	navBarControl1.EndUpdate();
    }
